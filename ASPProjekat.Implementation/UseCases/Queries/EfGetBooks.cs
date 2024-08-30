using ASPProjekat.ApplicationLayer.DTO;
using ASPProjekat.ApplicationLayer.Queries;
using ASPProjekat.DataAccess;
using ASPProjekat.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Queries
{
    //GET Books+Editions
    public class EfGetBooks : EfUseCase,IGetBooks
    {
        public EfGetBooks(ASPContext context) : base(context) { }
        public int Id => 1;
        public string Name => "Search Books";
        public PagedResponseDto<BookDto> Execute(BookSearchDto search)
        {
            var query = Context.Editions.AsQueryable();
            if (!string.IsNullOrEmpty(search.PublicationYear))
            {
                query = query.Where(x => x.Book.PublicationYear == search.PublicationYear);
            }
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Book.Title.Contains(search.Keyword)||x.Book.Description.Contains(search.Keyword));
            }
            if (search.AuthorId > 0)
            {
                query=query.Where(x=>x.Book.AuthorId == search.AuthorId);
            }
            if (!string.IsNullOrEmpty(search.Genre))
            {
                query = query.Where(x => x.Book.BookGenres.Any(x=>x.Genre.Name==search.Genre));
            }
            int totalCount = query.Count();
            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);
            return new PagedResponseDto<BookDto>
            {

                CurrentPage = page,
                TotalCount = totalCount,
                Data = query.Select(x => new BookDto
                {
                    Id = x.Id,
                    BookId=x.BookId,
                    Title = x.Book.Title,
                    Author = x.Book.Author.Name,
                    Description = x.Book.Description,
                    GenreNames = x.Book.BookGenres.Select(x => x.Genre.Name).ToList(),
                    ImagePath = x.Image.Path,
                    Isbn = x.Book.Isbn,
                    LatestPrice = x.Prices.OrderByDescending(x => x.CreatedAt).Select(x => x.Value).FirstOrDefault(),
                    Publisher = x.Publisher.Name,
                    ReleaseYear = x.Book.PublicationYear

                }).ToList(),
                PerPage = perPage
            };
        }
    }
}
