using ASPProjekat.ApplicationLayer.Commands;
using ASPProjekat.DataAccess;
using ASPProjekat.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Commands
{
    public class EfDeleteEdition:EfUseCase,IDeleteEdition
    {
        public int Id => 11;
        public string Name => "Delete Edition";
        public EfDeleteEdition(ASPContext context) : base(context){}
        public void Execute(int id)
        {
            
            Edition e=Context.Editions.First(x => x.Id == id);
            if (e!=null)
            {
                e.DeletedAt = DateTime.UtcNow;
                Context.SaveChanges();
            }
        }
    }
}
