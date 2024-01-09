using Grzymska.EpicFootwear.BLC;
using Grzymska.EpicFootwear.Interfaces;
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


        public BrandListViewModel()
        {
            _provider = App.Provider;
            _brands = new ObservableCollection<BrandViewModel>();
            OnPropertyChanged("Brands");
            GetAllBrands();

            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(Brands);
            _filterDataCommand = new RelayCommand(param => FilterData());
            //_addNewBrandCommand = new RelayCommand(param => { Add})
            _editBrandCommand = new RelayCommand(param => EditBrand());
            _deleteBrandCommand = new RelayCommand(param => DeleteBrand());
        }

        private void GetAllBrands()
        {
            foreach (var brand in _provider.GetAllBrands())
            {
                _brands.Add(new BrandViewModel(brand));
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
     
        private RelayCommand _filterDataCommand;
        public RelayCommand FilterDataCommand { get => _filterDataCommand; }
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

        private RelayCommand _addNewBrandCommand;
        public RelayCommand AddNewBrandCommand
        {
            get => _addNewBrandCommand;
        }
        private void AddNewBrand()
        {
            SelectedBrand = new BrandViewModel(_provider.NewBrand());
            SelectedBrand.Validate();
        }

        private RelayCommand _editBrandCommand;
        public RelayCommand EditBrandCommand
        {
            get => _editBrandCommand;
        }
        private void EditBrand()
        {
            // TODO: otwórz okno dodawania przekazując selectedBrand
        }

        private RelayCommand _deleteBrandCommand;
        public RelayCommand DeleteBrandsCommand
        {
            get => _deleteBrandCommand;
        }
        private void DeleteBrand()
        {
            _provider.DeleteBrand(SelectedBrand.Brand);
            Brands.Remove(SelectedBrand);
        }
    }
}
