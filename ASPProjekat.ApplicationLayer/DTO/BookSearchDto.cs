using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.ApplicationLayer.DTO
{
    public class BookSearchDto : PagedSearch
    {
        public string Keyword
        { get; set; } = "";
        public string PublicationYear { get; set; } = "";
        public string Genre { get; set; } = "";
        public int AuthorId { get; set; } = 0;

    }
}
