using ASPProjekat.ApplicationLayer.DTO;
using ASPProjekat.ApplicationLayer.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.ApplicationLayer.Queries
{
    public interface IGetUserOrders : IQuery<PagedResponseDto<UserOrdersDto>,UserOrdersSearchDto>
    {
    }
}
