namespace Grzymska.EpicFootwear.Interfaces
{
    public interface IBrand
    {
        int ID { get; set; }
        string Name { get; set; }
        string Country { get; set; }
        int Founded { get; set; }
    }
}
