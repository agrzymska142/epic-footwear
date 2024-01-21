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
using Grzymska.EpicFootwear.UI.Commands;

namespace Grzymska.EpicFootwear.UI.ViewModels
{
    internal class ShoeListViewModel : ViewModelBase
    {
        private ObservableCollection<ShoeViewModel> _shoes;
        public ObservableCollection<ShoeViewModel> Shoes => _shoes;

        private ListCollectionView _view;

        private CommandBase _filterDataCommand;
        public CommandBase FilterDataCommand { get => _filterDataCommand; }

        private DataProvider _provider;
        private NavigationService _navigationService;

        public string FilterValue { get; set; }

        public ShoeListViewModel(DataProvider provider, NavigationService navigationService)
        {
            _provider = provider;
            _navigationService = navigationService;
            OnPropertyChanged("Shoes");
            _shoes = new ObservableCollection<ShoeViewModel>();
            GetAllShoes();

            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(Shoes);
            _addNewShoeCommand = new NavigateCommand(navigationService);
            _deleteShoeCommand = new DeleteShoeCommand(this, provider);
        }

        private void GetAllShoes()
        {
            foreach (var shoe in _provider.GetAllShoes())
            {
                _shoes.Add(new ShoeViewModel(shoe, _provider, _navigationService));
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

        private CommandBase _addNewShoeCommand;
        public CommandBase AddNewShoeCommand
        {
            get => _addNewShoeCommand;
        }
        private void AddNewShoe()
        {
            SelectedShoe = new ShoeViewModel(_provider.NewShoe(), _provider, _navigationService);
            SelectedShoe.Validate();
        }


        private CommandBase _deleteShoeCommand;
        public CommandBase DeleteShoeCommand
        {
            get
            {
                OnPropertyChanged("Shoes");
                return _deleteShoeCommand;
            }
        }
    }
}
