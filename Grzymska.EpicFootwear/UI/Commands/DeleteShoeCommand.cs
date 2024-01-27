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
    internal class DeleteShoeCommand : CommandBase
    {
        private readonly DataProvider _provider;
        private readonly ShoeListViewModel _shoeListViewModel;

        public DeleteShoeCommand(ShoeListViewModel shoeListViewModel, DataProvider provider)
        {
            _shoeListViewModel = shoeListViewModel;
            _provider = provider;
        }

        public override void Execute(object parameter)
        {
            if (parameter is ShoeViewModel shoeViewModel)
            {
                _shoeListViewModel.Shoes.Remove(shoeViewModel);
                _provider.DeleteShoe(shoeViewModel.Shoe);
            }
        }
    }
}
