using Grzymska.EpicFootwear.Core;
using Grzymska.EpicFootwear.Interfaces;

namespace Grzymska.EpicFootwear.WEB.Models
{
    public class Shoe : IShoe
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Brand Brand { get; set; }
        IBrand IShoe.Brand
        {
            get => Brand;
            set => Brand = (Brand)value;
        }
        public ShoeType ShoeType { get; set; }
    }
}
    