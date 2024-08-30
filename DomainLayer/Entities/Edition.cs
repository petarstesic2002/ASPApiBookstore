using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.DomainLayer.Entities
{
    public class Edition:Entity
    {
        public int BookId {  get; set; }
        public virtual Book Book { get; set; }
        public int PublisherId {  get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<StoreEdition> EditionStores { get; set; } = new HashSet<StoreEdition>();
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }
        public virtual ICollection<Price> Prices { get; set; }=new HashSet<Price>();
        public virtual ICollection<Wishlist> EditionUsers { get; set; } =new HashSet<Wishlist>();
        public virtual ICollection<OrderItem> ItemOrders { get; set; }=new HashSet<OrderItem>();

    }
}
