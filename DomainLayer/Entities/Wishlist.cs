using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.DomainLayer.Entities
{
    public class Wishlist:Entity
    {
        public int UserId { get; set; }
        public int EditionId { get; set; }
        public virtual User User { get; set; }
        public virtual Edition Edition { get; set; }
    }
}
