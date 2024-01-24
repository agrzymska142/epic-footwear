using Grzymska.EpicFootwear.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Grzymska.EpicFootwear.DAOSQL
{
    public class DAO : IDAO
    {
        private DatabaseContext db = new DatabaseContext();

        public void DeleteBrand(IBrand brand)
        {
            db.Brands.Remove((Brand)brand);
            db.SaveChanges();
        }

        public void DeleteShoe(IShoe shoe)
        {
            db.Shoes.Remove((Shoe)shoe);
            db.SaveChanges();
        }

        public IEnumerable<IBrand> GetAllBrands()
        {
            return db.Brands;
        }

        public IEnumerable<IShoe> GetAllShoes()
        {
            return db.Shoes.Include(s => s.Brand).ToList();
        }

        public IBrand NewBrand()
        {
            return new Brand(0);
        }

        public IShoe NewShoe()
        {
            return new Shoe(0); 
        }

        public void SaveBrand(IBrand brand)
        {
            IBrand existingBrand = db.Brands.FirstOrDefault(b => b.ID == brand.ID);

            if (existingBrand != null)
            {
                existingBrand.Name = brand.Name;
                existingBrand.Country = brand.Country;
                existingBrand.Founded = brand.Founded;
            }
            else
            {
                db.Brands.Add((Brand)brand);
            }

            db.SaveChanges();
        }

        public void SaveShoe(IShoe shoe)
        {
            IShoe existingShoe = db.Shoes.FirstOrDefault(s => s.ID == shoe.ID);

            if (existingShoe != null)
            {
                existingShoe.Name = shoe.Name;
                existingShoe.Brand = shoe.Brand;
                existingShoe.ShoeType = shoe.ShoeType;
            }
            else
            {
                db.Shoes.Add((Shoe)shoe);
            }

            db.SaveChanges();
        }
    }
}
