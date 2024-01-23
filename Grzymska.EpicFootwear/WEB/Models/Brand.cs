using Grzymska.EpicFootwear.Interfaces;

namespace Grzymska.EpicFootwear.WEB.Models
{
    public class Brand : IBrand
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Founded { get; set; }
    }
}
