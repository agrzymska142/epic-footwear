using Grzymska.EpicFootwear.Interfaces;

namespace Grzymska.EpicFootwear.DAOMock
{
    public class Brand : IBrand
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Founded { get; set; }

        public Brand(int iD, string name, string country, int founded)
        {
            ID = iD;
            Name = name;
            Country = country;
            Founded = founded;
        }

        public Brand(int iD)
        {
            ID = iD;
            Name = "";
            Country = "";
            Founded = 0;
        }
    }
}
