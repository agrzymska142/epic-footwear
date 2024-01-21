using Grzymska.EpicFootwear.BLC;
using Grzymska.EpicFootwear.Core;
using Grzymska.EpicFootwear.Interfaces;
using Grzymska.EpicFootwear.UI.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Grzymska.EpicFootwear.UI.ViewModels
{
    internal class ShoeViewModel : ViewModelBase
    {
        private IShoe _shoe;
        public IShoe Shoe { get => _shoe; }

        private ObservableCollection<IBrand> _brands;
        public ObservableCollection<IBrand> Brands { get => _brands; }

        private ObservableCollection<ShoeType> _shoeTypes;
        public ObservableCollection<ShoeType> ShoeTypes { get => _shoeTypes; }

        private DataProvider _provider;

        public ShoeViewModel(IShoe shoe, DataProvider provider, NavigationService shoeListViewNavigationService)
        {
            _shoe = shoe;
            _provider = provider;
            _shoeTypes = new ObservableCollection<ShoeType>((IEnumerable<ShoeType>)Enum.GetValues(typeof(ShoeType)));
            GetAllBrands();

            _saveShoeCommand = new SubmitShoeCommand(this, provider, shoeListViewNavigationService);
            _cancelCommand = new NavigateCommand(shoeListViewNavigationService);
        }

        public ShoeViewModel(DataProvider provider, NavigationService shoeListViewNavigationService)
        {
            _provider = provider;
            _shoe = _provider.NewShoe();
            _shoeTypes = new ObservableCollection<ShoeType>((IEnumerable<ShoeType>)Enum.GetValues(typeof(ShoeType)));
            GetAllBrands();

            _saveShoeCommand = new SubmitShoeCommand(this, provider, shoeListViewNavigationService);
            _cancelCommand = new NavigateCommand(shoeListViewNavigationService);
        }

        private void GetAllBrands()
        {
            List<IBrand> listBrands = (List<IBrand>)_provider.GetAllBrands();
            _brands = new ObservableCollection<IBrand>(listBrands);
        }

        public int ID
        {
            get => _shoe.ID;
            set
            {
                _shoe.ID = value;
            }
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

        private CommandBase _saveShoeCommand;
        public CommandBase SaveShoeCommand
        {
            get => _saveShoeCommand;
        }
        private void SaveShoe()
        {
            _provider.SaveShoe(Shoe);
        }

        private CommandBase _cancelCommand;
        public CommandBase CancelCommand
        {
            get => _cancelCommand;
        }

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
