using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.DomainLayer.Entities
{
    public class Image:Entity
    {
        public string Path {  get; set; }
        public virtual ICollection<Edition> Editions { get; set; }=new HashSet<Edition>();
    }
}
