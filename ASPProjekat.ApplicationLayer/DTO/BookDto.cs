using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.ApplicationLayer.DTO
{
    //Edition+Book za Prikaz
    public class BookDto
    {
        public int Id { get; set; }
        public int BookId {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public decimal LatestPrice { get; set; }
        public string ReleaseYear {  get; set; }
        public string ImagePath { get; set; }
        public string Isbn {  get; set; }
        public string Publisher { get; set; }
        public IEnumerable<string> GenreNames {  get; set; }
    }
}
