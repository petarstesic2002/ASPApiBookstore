using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.ApplicationLayer.DTO
{
    public class BookAvailabilitySearchDto:PagedSearch
    {
        public string Book { get; set; } = "";
        public int BookId { get; set; } = 0;
    }
}
