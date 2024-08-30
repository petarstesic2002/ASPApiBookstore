using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.DomainLayer.Entities
{
    public class Genre : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<BookGenre> GenreBooks { get; set; } = new HashSet<BookGenre>();
    }
}
