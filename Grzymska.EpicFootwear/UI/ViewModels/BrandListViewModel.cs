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

        public string FilterValue { get; set; }
        public ListCollectionView View;

        private DataProvider _provider;

        private NavigationService _brandViewNavigationService;
        private NavigationService _brandListViewNavigationService;


        public BrandListViewModel(DataProvider provider, NavigationService brandViewNavigationService, NavigationService brandListViewNavigationService)
        {
            _provider = provider;
            _brands = new ObservableCollection<BrandViewModel>();
            _brandViewNavigationService = brandViewNavigationService;
            _brandListViewNavigationService = brandListViewNavigationService;

            OnPropertyChanged("Brands");
            GetAllBrands();
            View = (ListCollectionView)CollectionViewSource.GetDefaultView(Brands);

            _addNewBrandCommand = new NavigateCommand(brandViewNavigationService);
            _deleteBrandCommand = new DeleteBrandCommand(this, provider);
            _filterDataCommand = new FilterBrandsCommand(this);
        }

        private void GetAllBrands()
        {
            foreach (var brand in _provider.GetAllBrands())
            {
                _brands.Add(new BrandViewModel(brand, _provider, _brandListViewNavigationService));
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

     
        private CommandBase _filterDataCommand;
        public CommandBase FilterDataCommand 
        { 
            get => _filterDataCommand; 
        }

        private CommandBase _addNewBrandCommand;
        public CommandBase AddNewBrandCommand
        {
            get => _addNewBrandCommand;
        }

        private CommandBase _editBrandCommand;
        public CommandBase EditBrandCommand
        {
            get => _editBrandCommand;
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
