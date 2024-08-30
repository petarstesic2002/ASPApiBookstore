using ASPProjekat.ApplicationLayer.Commands;
using ASPProjekat.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPProjekat.Implementation.Validators;
using ASPProjekat.ApplicationLayer.DTO;
using FluentValidation;
using ASPProjekat.DomainLayer.Entities;

namespace ASPProjekat.Implementation.UseCases.Commands
{
    public class EfRegisterUser:EfUseCase,IRegisterUser
    {
        public int Id => 5;
        public string Name => "Create User";

       // private ASPContext Context;
        private RegisterUserValidator _validator;

        public EfRegisterUser(ASPContext context, RegisterUserValidator validator)
            : base(context)
        {
            _validator = validator;
        }
        
        public void Execute(RegisterUserDto data)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(data.Password);
            _validator.ValidateAndThrow(data);
            ASPProjekat.DomainLayer.Entities.User user = new ASPProjekat.DomainLayer.Entities.User
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Password = data.Password,
                RoleId = data.RoleId
            };
            Context.Users.Add(user);
            Context.SaveChanges();
        }
    }
}
