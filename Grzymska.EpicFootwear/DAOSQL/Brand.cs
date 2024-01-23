using Grzymska.EpicFootwear.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Grzymska.EpicFootwear.DAOSQL
{
    public class Brand : IBrand
    {
        [Key]
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
