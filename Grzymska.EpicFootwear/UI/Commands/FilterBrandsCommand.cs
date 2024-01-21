using Grzymska.EpicFootwear.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grzymska.EpicFootwear.UI.Commands
{
    internal class FilterBrandsCommand : CommandBase
    {
        private readonly BrandListViewModel _brandListViewModel;

        public FilterBrandsCommand(BrandListViewModel brandListViewModel)
        {
            _brandListViewModel = brandListViewModel;
        }

        public override void Execute(object parameter)
        {
            if (string.IsNullOrEmpty(_brandListViewModel.FilterValue))
            {
                _brandListViewModel.View.Filter = null;
            }
            else
            {
                _brandListViewModel.View.Filter = (c) => ((BrandViewModel)c).Name.Contains(_brandListViewModel.FilterValue);
            }
        }
    }
}
