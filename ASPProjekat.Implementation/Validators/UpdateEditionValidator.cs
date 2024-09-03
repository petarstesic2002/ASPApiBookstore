using ASPProjekat.ApplicationLayer.DTO;
using ASPProjekat.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Validators
{
    public class UpdateEditionValidator:AbstractValidator<UpdateEditionDto>
    {
        private readonly ASPContext _context;
        public UpdateEditionValidator(ASPContext ctx)
        {
            _context = ctx;
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Price).GreaterThan(0).When(x=>x.Price.HasValue);
            RuleFor(x => x.BookId)
                .GreaterThan(0).Must(InvalidBookId).WithMessage("Invalid Book Id").When(x=>x.BookId.HasValue);
            RuleFor(x => x.PublisherId).GreaterThan(0).Must(InvalidPublisherId).WithMessage("Invalid Publisher Id").When(x => x.PublisherId.HasValue);

        }
        private bool InvalidBookId(int? id)
        {
            bool value = true;
            if (!_context.Books.Any(x => x.Id == id))
            {
                value = false;
            }
            return value;
        }
        private bool InvalidPublisherId(int? id)
        {
            bool value = true;
            if (!_context.Publishers.Any(x => x.Id == id))
            {
                value = false;
            }
            return value;
        }
    }
}
