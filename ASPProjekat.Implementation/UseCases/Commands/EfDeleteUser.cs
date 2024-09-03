using ASPProjekat.DataAccess;
using ASPProjekat.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Commands
{
    public class EfDeleteUser:EfUseCase
    {
        public int Id => 14;
        public string Name => "Delete User";
        public EfDeleteUser(ASPContext context) : base(context) { }
        public void Execute(int id)
        {

            User u = Context.Users.First(x => x.Id == id);
            if (u != null)
            {
                u.DeletedAt = DateTime.UtcNow;
                Context.SaveChanges();
            }
        }
    }
}
