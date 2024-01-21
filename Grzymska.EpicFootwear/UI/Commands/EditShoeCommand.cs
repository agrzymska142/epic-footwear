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
    internal class EditShoeCommand : CommandBase
    {
        private readonly ShoeViewModel _shoeViewModel;
        private readonly NavigationService _shoeViewNavigationService;

        public EditShoeCommand(ShoeViewModel shoeViewModel, NavigationService shoeViewNavigationService)
        {
            _shoeViewModel = shoeViewModel;
            _shoeViewNavigationService = shoeViewNavigationService;
        }

        public override void Execute(object parameter)
        {
            _shoeViewNavigationService.Navigate(_shoeViewModel);
        }
    }
}
