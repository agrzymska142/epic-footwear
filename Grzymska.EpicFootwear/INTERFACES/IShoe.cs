using Grzymska.EpicFootwear.Core;

namespace Grzymska.EpicFootwear.Interfaces
{
    public interface IShoe
    {
        int ID { get; set; }
        string Name { get; set; }
        IBrand Brand { get; set; }
        ShoeType ShoeType { get; set; }
    }
}
