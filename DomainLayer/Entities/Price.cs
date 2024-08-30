using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.DomainLayer.Entities
{
    public class Price:Entity
    {
        public decimal Value {  get; set; }
        public int EditionId {  get; set; }
        public Edition Edition { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }=new HashSet<OrderItem>();
    }
}
