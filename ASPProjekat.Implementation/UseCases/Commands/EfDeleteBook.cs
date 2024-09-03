using ASPProjekat.ApplicationLayer.Commands;
using ASPProjekat.DataAccess;
using ASPProjekat.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Commands
{
    public class EfDeleteBook:EfUseCase,IDeleteBook
    {
        public int Id => 12;
        public string Name => "Delete Book";
        public EfDeleteBook(ASPContext context) : base(context) { }
        public void Execute(int id)
        {

            Book b = Context.Books.First(x => x.Id == id);
            if (b != null)
            {
                b.DeletedAt = DateTime.UtcNow;
                Context.SaveChanges();
            }
        }
    }
}
