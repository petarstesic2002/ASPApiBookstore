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
    public class EfCheckBookAvailability : EfUseCase, ICheckBookAvailability
    {
        public EfCheckBookAvailability(ASPContext context) : base(context) { }
        public int Id => 4;
        public string Name => "Check Book Availability";
        
        public PagedResponseDto<BookAvailabilityDto> Execute(BookAvailabilitySearchDto search)
        {
            var query = Context.Editions.AsQueryable();
            if (!string.IsNullOrEmpty(search.Book))
            {
                query=query.Where(x=>x.Book.Title == search.Book);
            }
            if (search.BookId > 0)
            {
                query = query.Where(x => x.Book.Id == search.BookId);
            }
            int totalCount = query.Count();
            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);
            return new PagedResponseDto<BookAvailabilityDto>
            {
                Data = query.Select(x => new BookAvailabilityDto
                {
                    EditionId = x.Id,
                    Title = x.Book.Title,
                    LatestPrice = x.Prices.OrderByDescending(x => x.CreatedAt).Select(x => x.Value).FirstOrDefault(),
                    AvailableStores = x.EditionStores.Select(x => new EditionStoreDto
                    {
                        StoreId = x.StoreId
                    })

                }).ToList(),
                TotalCount = totalCount,
                CurrentPage = page,
                PerPage = perPage
            };

        } 
    }
}
