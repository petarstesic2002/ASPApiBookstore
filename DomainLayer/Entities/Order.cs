using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.DomainLayer.Entities
{
    public class Order : Entity
    {
        public int UserId {  get; set; }
        public virtual User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }=new HashSet<OrderItem>();

    }
}
