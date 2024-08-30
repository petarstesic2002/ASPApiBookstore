using ASPProjekat.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        private readonly ASPContext _context;
        protected EfUseCase(ASPContext context)
        {
            _context = context;
        }
        protected ASPContext Context => _context;
    }
}
