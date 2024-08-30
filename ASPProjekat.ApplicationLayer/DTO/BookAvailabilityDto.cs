using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.ApplicationLayer.DTO
{
    public class BookAvailabilityDto
    {
        public int EditionId {  get; set; }
        public string Title { get; set; }
        public decimal LatestPrice {  get; set; }
        public IEnumerable<EditionStoreDto> AvailableStores { get; set; }
    }
}
