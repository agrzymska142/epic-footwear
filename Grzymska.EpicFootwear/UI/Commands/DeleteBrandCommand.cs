using Grzymska.EpicFootwear.BLC;
using Grzymska.EpicFootwear.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grzymska.EpicFootwear.UI.Commands
{
    internal class DeleteBrandCommand : CommandBase
    {
        private readonly DataProvider _provider;
        private readonly BrandListViewModel _brandListViewModel;

        public DeleteBrandCommand(BrandListViewModel brandListViewModel, DataProvider provider)
        {
            _brandListViewModel = brandListViewModel;
            _provider = provider;
        }

        public override void Execute(object parameter)
        {
            if (parameter is BrandViewModel brandViewModel)
            {
                _brandListViewModel.Brands.Remove(brandViewModel);
                _provider.DeleteBrand(brandViewModel.Brand);
            }
        }
    }
}
