using Grzymska.EpicFootwear.Interfaces;
using System.Reflection;

namespace Grzymska.EpicFootwear.BLC
{
    public class DataProvider
    {
        private IDAO DAO;

        public DataProvider(string daoPath)
        {
            Assembly a = Assembly.UnsafeLoadFrom(daoPath); 
            Type classToCreate = null;

            foreach (Type type in a.GetTypes())
            {
                if (type.GetInterfaces().Contains<Type>(typeof(IDAO)))
                {
                    classToCreate = type;
                    break;
                }
            }

            if (classToCreate != null)
            {
                DAO = (IDAO)Activator.CreateInstance(classToCreate, []);
            }
        }

        public IEnumerable<IBrand> GetAllBrands()
        {
            return DAO.GetAllBrands();
        }

        public IEnumerable<IShoe> GetAllShoes()
        {
            return DAO.GetAllShoes();
        }

        public void SaveBrand(IBrand brand)
        {
            DAO.SaveBrand(brand);
        }

        public void SaveShoe(IShoe shoe) 
        {
            DAO.SaveShoe(shoe);
        }

        public IBrand NewBrand() 
        { 
            return DAO.NewBrand(); 
        } 

        public IShoe NewShoe()
        {
            return DAO.NewShoe();
        }

        public void DeleteBrand(IBrand brand)
        {
            DAO.DeleteBrand(brand);
        }

        public void DeleteShoe(IShoe shoe)
        {
            DAO.DeleteShoe(shoe);
        }
    }
}
