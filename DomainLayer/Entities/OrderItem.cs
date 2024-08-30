using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.DomainLayer.Entities
{
    public class OrderItem:Entity
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int EditionId {  get; set; }
        public virtual Edition Edition  { get; set; }
        public int PriceId {  get; set; }
        public virtual Price Price { get; set; }
        public int Quantity { get; set; }
    }
}
