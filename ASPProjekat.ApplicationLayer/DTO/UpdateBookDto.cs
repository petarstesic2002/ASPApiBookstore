using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.ApplicationLayer.DTO
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? AuthorId { get; set; }
        public IEnumerable<int>? GenreIds { get; set; }
        public string? Isbn { get; set; }
        public string? PublicationYear { get; set; }
    }
}
