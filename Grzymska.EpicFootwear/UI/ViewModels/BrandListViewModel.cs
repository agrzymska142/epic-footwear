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
        public ObservableCollection<BrandViewModel> Brands { get; set; } = new ObservableCollection<BrandViewModel>();

        private ListCollectionView _view;

        private RelayCommand _filterDataCommand;
        public RelayCommand FilterDataCommand { get => _filterDataCommand; }

        private DataProvider _provider;

        public string FilterValue { get; set; }

        public BrandListViewModel()
        {
            _provider = MainWindow.Provider;
            OnPropertyChanged("Brands");
            GetAllBrands();

            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(Brands);
            _filterDataCommand = new RelayCommand(param => FilterData());
            //_addNewBrandCommand = new RelayCommand(param => { Add})
            _deleteBrandCommand = new RelayCommand(param => DeleteBrand());
        }

        private void GetAllBrands()
        {
            _provider.GetAllBrands();
        }

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

        private RelayCommand _addNewBrandCommand;
        public RelayCommand AddNewBrandsCommand
        {
            get => _addNewBrandCommand;
        }
        private void AddNewBrand()
        {
            SelectedBrand = new BrandViewModel(_provider.NewBrand());
            SelectedBrand.Validate();
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
