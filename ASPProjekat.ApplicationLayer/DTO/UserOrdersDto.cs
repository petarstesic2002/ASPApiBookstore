using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.ApplicationLayer.DTO
{
    public class UserOrdersDto
    {
        public int UserId { get; set; }
        public string FullName {  get; set; }
        public int OrderId { get; set; }
        public DateTime OrderedAt {  get; set; }
        public IEnumerable<OrderItemDto> OrderBooks { get; set; }
    }
}
