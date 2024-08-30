using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.ApplicationLayer.DTO
{
    public class CreateOrderDto
    {
        public int UserId {  get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
    }
}
