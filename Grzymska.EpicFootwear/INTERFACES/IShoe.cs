namespace Grzymska.EpicFootwear.Interfaces
{
    public interface IShoe
    {
        int ID { get; set; }
        String Name { get; set; }
        IBrand Brand { get; set; }
        
        // TODO: dodaj enumy
    }
}
