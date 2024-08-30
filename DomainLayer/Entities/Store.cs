using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.DomainLayer.Entities
{
    public class Store : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int CityId {  get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<StoreEdition> StoreEditions { get; set; } = new HashSet<StoreEdition>();
    }
}
