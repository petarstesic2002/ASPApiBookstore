using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.DomainLayer.Entities
{
    public class City : Entity
    {
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Store> Stores {  get; set; } =new HashSet<Store>();
    }
}
