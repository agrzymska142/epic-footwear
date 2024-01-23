using Grzymska.EpicFootwear.Core;
using Grzymska.EpicFootwear.Interfaces;

namespace Grzymska.EpicFootwear.WEB.Models
{
    public class Shoe : IShoe
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public ShoeType ShoeType { get; set; }
        IBrand IShoe.Brand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
