using ASPProjekat.ApplicationLayer.DTO;
using ASPProjekat.ApplicationLayer.Queries;
using ASPProjekat.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Queries
{
    public class EfGetUserOrders:EfUseCase,IGetUserOrders
    {
        public EfGetUserOrders(ASPContext context) : base(context) { }
        public int Id => 3;
        public string Name => "Search Orders";
        public PagedResponseDto<UserOrdersDto> Execute(UserOrdersSearchDto search)
        {
            var query=Context.Orders.AsQueryable();
            if (search.UserId > 0)
            {
                query=query.Where(x=>x.UserId==search.UserId);
            }
            if (!string.IsNullOrEmpty(search.Name))
            {
                query=query.Where(x=>x.User.FirstName==search.Name||x.User.LastName==search.Name);
            }
            int totalCount = query.Count();
            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);
            return new PagedResponseDto<UserOrdersDto>
            {
                Data = query.Select(x => new UserOrdersDto
                {
                    UserId = x.UserId,
                    OrderedAt = x.CreatedAt,
                    FullName = x.User.FirstName + " " + x.User.LastName,
                    OrderBooks = x.OrderItems.Select(x => new OrderItemDto
                    {
                        EditionId = x.EditionId,
                        PriceId = x.PriceId,
                        Quantity=x.Quantity
                    }).ToList(),
                    OrderId = x.Id
                }).ToList(),
                CurrentPage = page,
                TotalCount = totalCount,
                PerPage=perPage
            };
        }
    }
}
