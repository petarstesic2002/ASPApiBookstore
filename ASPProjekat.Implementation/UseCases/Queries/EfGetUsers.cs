using ASPProjekat.ApplicationLayer.DTO;
using ASPProjekat.ApplicationLayer.Queries;
using ASPProjekat.ApplicationLayer.UseCase;
using ASPProjekat.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Queries
{
    public class EfGetUsers : EfUseCase, IGetUsers
    {
        public EfGetUsers(ASPContext context):base(context) { }
        public int Id => 2;

        string IUseCase.Name => "Search Users";
        public PagedResponseDto<UserDto> Execute(UserSearchDto search)
        {
            var query=Context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query=query.Where(x=>x.Email.Contains(search.Keyword)
                                    ||x.FirstName.Contains(search.Keyword)
                                    ||x.LastName.Contains(search.Keyword));
            }
            int totalCount=query.Count();
            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);
            return new PagedResponseDto<UserDto>
            {
                CurrentPage = page,
                TotalCount = totalCount,
                Data = query.Select(x => new UserDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Role = x.Role.Name,
                    WishlistNumber = x.UserEditions.Count()

                }).ToList(),
                PerPage=perPage
            };
        }
    }
}
