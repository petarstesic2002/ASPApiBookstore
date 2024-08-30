using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.DomainLayer.Entities
{
    public class Publisher:Entity
    {
        public string Name {  get; set; }
        public virtual ICollection<Edition> Editions { get; set; }=new HashSet<Edition>();
    }
}
