using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Grzymska.EpicFootwear.BLC;
using Grzymska.EpicFootwear.DAOMock;
using Grzymska.EpicFootwear.Interfaces;

namespace Grzymska.EpicFootwear.UI.ViewModels
{
    internal class ShoeListViewModel : ViewModelBase
    {
        private ObservableCollection<ShoeViewModel> _shoes;
        public ObservableCollection<ShoeViewModel> Shoes => _shoes;

        private ListCollectionView _view;

        private RelayCommand _filterDataCommand;
        public RelayCommand FilterDataCommand { get => _filterDataCommand; }

        private DataProvider _provider;

        public string FilterValue { get; set; }

        public ShoeListViewModel()
        {
            _provider = App.Provider;
            OnPropertyChanged("Shoes");
            _shoes = new ObservableCollection<ShoeViewModel>();
            GetAllShoes();

            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(Shoes);
            _filterDataCommand = new RelayCommand(param => FilterData());
            //_addNewShoeCommand = new RelayCommand(param => { Add})
            _deleteShoeCommand = new RelayCommand(param => DeleteShoe());
        }

        private void GetAllShoes()
        {
            foreach (var shoe in _provider.GetAllShoes())
            {
                _shoes.Add(new ShoeViewModel(shoe));
            }
        }

        private void FilterData()
        {
            if (string.IsNullOrEmpty(FilterValue))
            {
                _view.Filter = null;
            }
            else
            {
                _view.Filter = (c) => ((ShoeViewModel)c).Name.Contains(FilterValue);
            }
        }

        private ShoeViewModel _selectedShoe;
        public ShoeViewModel SelectedShoe
        {
            get => _selectedShoe;
            set
            {
                _selectedShoe = value;
                OnPropertyChanged("EditedShoe");
            }
        }

        private RelayCommand _addNewShoeCommand;
        public RelayCommand AddNewShoesCommand
        {
            get => _addNewShoeCommand;
        }
        private void AddNewShoe()
        {
            SelectedShoe = new ShoeViewModel(_provider.NewShoe());
            SelectedShoe.Validate();
        }

        private RelayCommand _deleteShoeCommand;
        public RelayCommand DeleteShoesCommand
        {
            get => _deleteShoeCommand;
        }
        private void DeleteShoe()
        {
            _provider.DeleteShoe(SelectedShoe.Shoe);
            Shoes.Remove(SelectedShoe);
        }
    }
}
