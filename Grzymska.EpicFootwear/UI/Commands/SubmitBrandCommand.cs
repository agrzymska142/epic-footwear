using Grzymska.EpicFootwear.BLC;
using Grzymska.EpicFootwear.Interfaces;
using Grzymska.EpicFootwear.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grzymska.EpicFootwear.UI.Commands
{
    internal class SubmitBrandCommand : CommandBase
    {
        private readonly DataProvider _provider;
        private readonly BrandViewModel _brandViewModel;
        private readonly NavigationService _brandListNavigationService;

        public SubmitBrandCommand(BrandViewModel brandViewModel, DataProvider provider, NavigationService brandListNavigationService)
        {
            _brandViewModel = brandViewModel;
            _provider = provider;
            _brandListNavigationService = brandListNavigationService;
        }

        public override void Execute(object parameter)
        {
            IBrand brand = _brandViewModel.Brand;

            _provider.SaveBrand(brand);

            _brandListNavigationService.Navigate();
        }
    }
}
