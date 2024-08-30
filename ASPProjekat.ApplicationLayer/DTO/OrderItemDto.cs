using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.ApplicationLayer.DTO
{
    public class OrderItemDto
    {
        public int EditionId {  get; set; }
        public int PriceId {  get; set; }
        public int Quantity { get; set; }
    }
}
