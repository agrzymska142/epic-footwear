﻿using Grzymska.EpicFootwear.BLC;
using Grzymska.EpicFootwear.Core;
using Grzymska.EpicFootwear.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grzymska.EpicFootwear.UI.ViewModels
{
    internal class ShoeViewModel : ViewModelBase
    {
        private IShoe _shoe;
        public IShoe Shoe { get => _shoe; }

        private ObservableCollection<IBrand> _brands;
        public ObservableCollection<IBrand> Brands { get => _brands; }

        private DataProvider _provider;

        public ShoeViewModel(IShoe shoe, List<IBrand> listBrands, DataProvider provider)
        {
            _shoe = shoe;
            _brands = new ObservableCollection<IBrand>(listBrands);
            _provider = provider;

            _saveShoeCommand = new RelayCommand(param => SaveShoe());
            //cancel command
        }


        [Required(ErrorMessage = "Name must be specified!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters long!")]
        public string Name
        {
            get => _shoe.Name;
            set
            {
                _shoe.Name = value;
                Validate();
                OnPropertyChanged("Name");
            }
        }

        [Required(ErrorMessage = "Brand must be specified!")]
        public IBrand Brand
        {
            get => _shoe.Brand;
            set
            {
                _shoe.Brand = value;
                Validate();
                OnPropertyChanged("Brand");
            }
        }

        [Required(ErrorMessage = "Type must be specified!")]
        public ShoeType ShoeType
        {
            get => _shoe.ShoeType;
            set
            {
                _shoe.ShoeType = value;
                Validate();
                OnPropertyChanged("ShoeType");
            }
        }

        private RelayCommand _saveShoeCommand;
        public RelayCommand SaveShoeCommand
        {
            get => _saveShoeCommand;
        }
        private void SaveShoe()
        {
            _provider.SaveShoe(Shoe);
        }

        private RelayCommand _cancelCommand;
        /*public RelayCommand CancelCommand
        {
            TODO
        }*/

        public void Validate()
        {
            var validationContext = new ValidationContext(this, null, null);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(this, validationContext, validationResults, true);

            foreach (var kv in _errors.ToList())
            {
                if (validationResults.All(r => r.MemberNames.All(m => m != kv.Key)))
                {
                    _errors.Remove(kv.Key);
                    RaiseErrorChanged(kv.Key);
                }
            }

            var q = from r in validationResults
                    from m in r.MemberNames
                    group r by m into g
                    select g;

            foreach (var prop in q)
            {
                var messages = prop.Select(r => r.ErrorMessage).ToList();

                if (_errors.ContainsKey(prop.Key))
                {
                    _errors.Remove(prop.Key);
                }
                _errors.Add(prop.Key, messages);

                RaiseErrorChanged(prop.Key);
            }
        }

    }
}