namespace Grzymska.EpicFootwear.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IShoe> GetAllCameras();
        IEnumerable<IBrand> GetAllBrands();

        IShoe SaveCamera(IShoe shoe);
        IBrand SaveBrand(IBrand brand);

        IShoe NewCamera();
        IBrand NewBrand();

        void DeleteBrand(IBrand brand);
        void DeleteCamera(IShoe shoe);
    }
}
