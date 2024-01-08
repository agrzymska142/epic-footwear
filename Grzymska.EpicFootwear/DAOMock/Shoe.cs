using Grzymska.EpicFootwear.Core;
using Grzymska.EpicFootwear.Interfaces;
using System.Xml.Linq;

namespace Grzymska.EpicFootwear.DAOMock
{
    public class Shoe : IShoe
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IBrand Brand { get; set; }
        public ShoeType ShoeType { get; set; }
        
        public Shoe(int iD, string name, IBrand brand, ShoeType shoeType)
        {
            ID = iD;
            Name = name;
            Brand = brand;
            ShoeType = shoeType;
        }

        public Shoe(int iD)
        {
            ID = iD; ;
            Name = "";
            Brand = null;
            ShoeType = ShoeType.Sneakers;
        }
    }
}
