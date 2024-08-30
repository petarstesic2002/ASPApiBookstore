using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.ApplicationLayer.Uploads
{
    public class AllowedExtensions
    {
        public IEnumerable<string> Extensions => new List<string>
        {
            "jpg", "png"
        };
    }
}
