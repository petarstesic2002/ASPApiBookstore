using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.ApplicationLayer.DTO
{
    public class UserOrdersSearchDto : PagedSearch
    {
        public int UserId { get; set; } = 0;
        public string Name { get; set; } = "";
    }
}
