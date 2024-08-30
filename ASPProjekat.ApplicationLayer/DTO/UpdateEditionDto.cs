using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.ApplicationLayer.DTO
{
    public class UpdateEditionDto
    {
        public int Id { get; set; }
        public int? BookId {  get; set; }
        public ImageDto? Image { get; set; }
        public IEnumerable<EditionStoreDto>? AvailableStores {  get; set; }
        public decimal? Price {  get; set; }
        public int? PublisherId {  get; set; }

    }
}
