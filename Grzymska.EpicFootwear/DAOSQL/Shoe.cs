using Grzymska.EpicFootwear.Core;
using Grzymska.EpicFootwear.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Grzymska.EpicFootwear.DAOSQL
{
    public class Shoe : IShoe
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public ShoeType ShoeType { get; set; }
        IBrand IShoe.Brand { get => Brand; set => Brand = (Brand)value; }

        public Shoe(int iD, string name, Brand brand, ShoeType shoeType)
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
