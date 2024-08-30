using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.DomainLayer.Entities
{
    public class StoreEdition : Entity
    {
        public int StoreId { get; set; }
        public int EditionId {  get; set; }
        public virtual Store Store { get; set; }
        public virtual Edition Edition { get; set; }
    }
}
