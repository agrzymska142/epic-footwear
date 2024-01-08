namespace Grzymska.EpicFootwear.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IShoe> GetAllShoes();
        IEnumerable<IBrand> GetAllBrands();

        void SaveShoe(IShoe shoe);
        void SaveBrand(IBrand brand);

        IShoe NewShoe();
        IBrand NewBrand();

        void DeleteBrand(IBrand brand);
        void DeleteShoe(IShoe shoe);
    }
}
