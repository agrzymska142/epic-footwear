using Grzymska.EpicFootwear.BLC;
using Grzymska.EpicFootwear.Interfaces;
using Grzymska.EpicFootwear.UI.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Grzymska.EpicFootwear.UI.ViewModels
{
    internal class BrandListViewModel : ViewModelBase
    {
        private ObservableCollection<BrandViewModel> _brands;
        public ObservableCollection<BrandViewModel> Brands => _brands;

        private ListCollectionView _view;

        private DataProvider _provider;

        private NavigationService _brandViewNavigationService;


        public BrandListViewModel(DataProvider provider, NavigationService brandViewNavigationService)
        {
            _provider = provider;
            _brands = new ObservableCollection<BrandViewModel>();
            OnPropertyChanged("Brands");
            GetAllBrands();
            _brandViewNavigationService = brandViewNavigationService;

            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(Brands);
            _addNewBrandCommand = new NavigateCommand(brandViewNavigationService);
            _deleteBrandCommand = new DeleteBrandCommand(this, provider);
        }

        private void GetAllBrands()
        {
            foreach (var brand in _provider.GetAllBrands())
            {
                _brands.Add(new BrandViewModel(brand, _provider, _brandViewNavigationService));
            }
        }

        private BrandViewModel _selectedBrand;
        public BrandViewModel SelectedBrand
        {
            get => _selectedBrand;
            set
            {
                _selectedBrand = value;
                OnPropertyChanged("EditedBrand");
            }
        }

        public string FilterValue { get; set; }
     
        private CommandBase _filterDataCommand;
        public CommandBase FilterDataCommand { get => _filterDataCommand; }
        private void FilterData()
        {
            if (string.IsNullOrEmpty(FilterValue))
            {
                _view.Filter = null;
            }
            else
            {
                _view.Filter = (c) => ((BrandViewModel)c).Name.Contains(FilterValue);
            }
        }

        private CommandBase _addNewBrandCommand;
        public CommandBase AddNewBrandCommand
        {
            get => _addNewBrandCommand;
        }
        private void AddNewBrand()
        {
            SelectedBrand = new BrandViewModel(_provider.NewBrand(), _provider, _brandViewNavigationService);
            SelectedBrand.Validate();
        }

        private CommandBase _editBrandCommand;
        public CommandBase EditBrandCommand
        {
            get => _editBrandCommand;
        }
        private void EditBrand()
        {
            // TODO: otwórz okno dodawania przekazując selectedBrand
        }

        private CommandBase _deleteBrandCommand;
        public CommandBase DeleteBrandCommand
        {
            get
            {
                OnPropertyChanged("Brands");
                return _deleteBrandCommand;
            }
        }
    }
}
