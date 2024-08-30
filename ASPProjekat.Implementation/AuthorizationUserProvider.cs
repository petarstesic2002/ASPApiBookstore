using ASPProjekat.ApplicationLayer.UseCase;
using ASPProjekat.DataAccess;
using ASPProjekat.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation
{
    public class AuthorizationUserProvider : IUserUseCaseProvider
    {
        private string _authorizationHeader;
        private ASPContext _context;

        public AuthorizationUserProvider(string authorizationHeader, ASPContext context)
        {
            _authorizationHeader = authorizationHeader;
            _context = context;
        }
        public IUserUseCase getUser()
        {
            //if(_authorizationHeader == null)
            //{
            //    return new UnauthorizedUser();
            //}
            //var base64data = _authorizationHeader.Split(" ")[1];
            //var bytes=Convert.FromBase64String(base64data);
            //var decoded=Encoding.UTF8.GetString(bytes);
            //if (decoded.Split(":").Length < 2)
            //{
            //    throw new InvalidOperationException("Invalid Authorization Header.");
            //}
            //string email = decoded.Split(":")[0];
            //string password = decoded.Split(":")[1];
            //DomainLayer.Entities.User user = _context.Users.Include(x => x.Role).FirstOrDefault(x => x.Email == email && x.Password == password);
            //if (user == null)
            //{
            //    return new UnauthorizedUser();
            //}
            //var useCases=user.Role.RoleUseCases.Select(x=>x.UseCaseId).ToList();
            //return new UserImplementation
            //{
            //    Id = user.Id,
            //    Email = user.Email,
            //    AllowedUseCases = useCases
            //};
            var data = _authorizationHeader.ToString().Split("Bearer ");
            if (data.Length < 2)
            {
                return new UnauthorizedUser();
            }
            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(data[1].ToString());

            var claims = tokenObj.Claims;

            var email = claims.First(x => x.Type == "Email").Value;
            var id = claims.First(x => x.Type == "Id").Value;
            var useCases = claims.First(x => x.Type == "UseCases").Value;

            List<int> useCaseIds = JsonConvert.DeserializeObject<List<int>>(useCases);

            return new UserImplementation
            {
                Id = int.Parse(id),
                AllowedUseCases = useCaseIds,
                Email = email
            };
        }
    }
}
