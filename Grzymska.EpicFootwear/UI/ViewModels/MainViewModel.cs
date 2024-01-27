using Grzymska.EpicFootwear.BLC;
using Grzymska.EpicFootwear.UI.Commands;
using Grzymska.EpicFootwear.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grzymska.EpicFootwear.UI.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore, NavigationService shoeListViewNavigationService, NavigationService brandListViewNavigationService)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _seeShoeListCommand = new NavigateCommand(shoeListViewNavigationService);
            _seeBrandListCommand = new NavigateCommand(brandListViewNavigationService);
        }

        private CommandBase _seeShoeListCommand;
        public CommandBase SeeShoeListCommand
        {
            get => _seeShoeListCommand;
        }

        private CommandBase _seeBrandListCommand;
        public CommandBase SeeBrandListCommand
        {
            get => _seeBrandListCommand;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel)); 
        }
    }
}
