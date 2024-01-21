using Grzymska.EpicFootwear.BLC;
using Grzymska.EpicFootwear.Interfaces;
using Grzymska.EpicFootwear.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grzymska.EpicFootwear.UI.Commands
{
    internal class SubmitShoeCommand : CommandBase
    {
        private readonly DataProvider _provider;
        private readonly ShoeViewModel _shoeViewModel;
        private readonly NavigationService _shoeListViewNavigationService;

        public SubmitShoeCommand(ShoeViewModel shoeViewModel, DataProvider provider, NavigationService shoeListViewNavigationService)
        {
            _shoeViewModel = shoeViewModel;
            _provider = provider;   
            _shoeListViewNavigationService = shoeListViewNavigationService;
        }

        public override void Execute(object parameter)
        {
            IShoe shoe = _shoeViewModel.Shoe;

            _provider.SaveShoe(shoe);

            _shoeListViewNavigationService.Navigate();
        }
    }
}
