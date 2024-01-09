using Grzymska.EpicFootwear.BLC;
using Grzymska.EpicFootwear.DAOMock;
using Grzymska.EpicFootwear.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grzymska.EpicFootwear.UI.ViewModels
{
    internal class BrandViewModel : ViewModelBase
    {
        private IBrand _brand;
        public IBrand Brand { get => _brand; }

        private DataProvider _provider;

        public BrandViewModel(IBrand brand)
        {
            _provider = App.Provider;
            _brand = brand;

            _saveBrandCommand = new RelayCommand(param => SaveBrand());
            // cancel command
        }

        // raczej do usunięcia później
        public BrandViewModel()
        {
            _provider = App.Provider; ;
            _brand = _provider.NewBrand();
        }

        public int ID
        {
            get => _brand.ID;
            set
            {
                _brand.ID = value;
            }
        }

        [Required(ErrorMessage = "Name must be specified!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters long!")]
        public string Name
        {
            get => _brand.Name;
            set
            {
                _brand.Name = value;
                Validate();
                OnPropertyChanged("Name");
            }
        }

        [Required(ErrorMessage = "Country must be specified!")]
        public string Country
        {
            get => _brand.Country;
            set
            {
                _brand.Country = value;
                Validate();
                OnPropertyChanged("Country");
            }
        }

        [Required(ErrorMessage = "Foundation year must be specified!")]
        [Range(1, 2024, ErrorMessage = "Year must be between 1 and 2024!")]
        public int Founded
        {
            get => _brand.Founded;
            set
            {
                _brand.Founded = value;
                Validate();
                OnPropertyChanged("Founded");
            }
        }

        private RelayCommand _saveBrandCommand;
        public RelayCommand SaveBrandCommand
        {
            get => _saveBrandCommand;
        }
        private void SaveBrand()
        {
            _provider.SaveBrand(Brand);
        }

        private RelayCommand _cancelCommand;
        // TODO
        public RelayCommand CancelCommand;

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
