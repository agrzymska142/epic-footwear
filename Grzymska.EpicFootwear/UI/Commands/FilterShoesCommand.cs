using Grzymska.EpicFootwear.BLC;
using Grzymska.EpicFootwear.UI.ViewModels;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grzymska.EpicFootwear.UI.Commands
{
    internal class FilterShoesCommand : CommandBase
    {
        private readonly ShoeListViewModel _shoeListViewModel;

        public FilterShoesCommand(ShoeListViewModel shoeListViewModel)
        {
            _shoeListViewModel = shoeListViewModel;
        }

        public override void Execute(object parameter)
        {
            if (string.IsNullOrEmpty(_shoeListViewModel.FilterValue))
            {
                _shoeListViewModel.View.Filter = null;
            }
            else
            {
                _shoeListViewModel.View.Filter = (c) => ((ShoeViewModel)c).Name.ToLower().Contains(_shoeListViewModel.FilterValue.ToLower());
            }
        }
    }
}
