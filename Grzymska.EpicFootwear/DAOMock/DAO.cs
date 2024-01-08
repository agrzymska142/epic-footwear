using Grzymska.EpicFootwear.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace Grzymska.EpicFootwear.DAOMock
{
    public class DAO : IDAO
    {
        private List<IBrand> _brands;
        private List<IShoe> _shoes;
        private int nextBrandId = 4;
        private int nextShoeId = 7;

        public DAO() 
        {
            _brands =
            [
                new Brand(1, "Nike", "USA", 1964),
                new Brand(2, "Ryłko", "Poland", 1964),
                new Brand(3, "Dr. Martens", "Germany", 1945)
            ];

            _shoes =
            [
                new Shoe(1, "Air Jordan 1 Mid", _brands[0], Core.ShoeType.Sneakers),
                new Shoe(2, "Ofelia", _brands[1], Core.ShoeType.Heels),
                new Shoe(3, "1460 Pascal Virginia", _brands[2], Core.ShoeType.Boots),
                new Shoe(4, "Metcon 9", _brands[0], Core.ShoeType.Sport),
                new Shoe(5, "Andie", _brands[1], Core.ShoeType.Sandals),
                new Shoe(6, "Myles Brando", _brands[3], Core.ShoeType.Sandals)
            ];
        }

        public IEnumerable<IBrand> GetAllBrands()
        {
            return _brands;
        }

        public IEnumerable<IShoe> GetAllShoes()
        {
            return _shoes;
        }

        public void SaveBrand(IBrand brand)
        {
            _brands.Add(brand);
        }

        public void SaveShoe(IShoe shoe)
        {
            _shoes.Add(shoe);
        }

        public IBrand NewBrand()
        {
            return new Brand(nextBrandId++);
        }

        public IShoe NewShoe()
        {
            return new Shoe(nextShoeId++);
        }

        public void DeleteBrand(IBrand brand)
        {
            _brands.Remove(brand);
        }

        public void DeleteShoe(IShoe shoe)
        {
            _shoes.Remove(shoe);
        }
    }
}
