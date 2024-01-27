using Grzymska.EpicFootwear.BLC;
using Grzymska.EpicFootwear.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grzymska.EpicFootwear.UI.Commands
{
    internal class EditBrandCommand : CommandBase
    {
        private readonly BrandViewModel _brandViewModel;
        private readonly NavigationService _brandViewNavigationService;

        public EditBrandCommand(BrandViewModel brandViewModel, NavigationService brandViewNavigationService)
        {
            _brandViewModel = brandViewModel;
            _brandViewNavigationService = brandViewNavigationService;
        }

        public override void Execute(object parameter)
        {
            _brandViewNavigationService.Navigate(_brandViewModel);
        }
    }
}
