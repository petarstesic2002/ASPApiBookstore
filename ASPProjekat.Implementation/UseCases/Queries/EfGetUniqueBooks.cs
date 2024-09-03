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
    public class EfGetUniqueBooks:EfUseCase,IGetUniqueBooks
    {
        public EfGetUniqueBooks(ASPContext context) : base(context) { }
        public int Id => 13;
        public string Name => "Search Unique Books";
        public PagedResponseDto<UniqueBookDto> Execute(UniqueBookSearchDto search)
        {
            var query = Context.Books.AsQueryable();
            if (search.Id.HasValue)
            {
                query=query.Where(x=>x.Id==search.Id);
            }
            int totalCount = query.Count();
            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);
            return new PagedResponseDto<UniqueBookDto>
            {
                Data = query.Select(x => new UniqueBookDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    DeletedAt = x.DeletedAt,
                    Description = x.Description

                }).ToList(),
                TotalCount = totalCount,
                PerPage = perPage,
                CurrentPage = page
            };
        }
    }
}
