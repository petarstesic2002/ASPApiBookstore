using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.DomainLayer.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Wishlist> UserEditions { get; set; } = new HashSet<Wishlist>();
        public virtual ICollection<UseCaseLog> UseCaseLogs { get; set; }=new HashSet<UseCaseLog>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
