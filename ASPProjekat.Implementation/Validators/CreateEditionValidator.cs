using ASPProjekat.ApplicationLayer.DTO;
using ASPProjekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Validators
{
    public class CreateEditionValidator : AbstractValidator<CreateEditionDto>
    {
        private readonly ASPContext _context;
        public CreateEditionValidator(ASPContext ctx)
        {
            _context = ctx;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.BookId)
                .NotEmpty().GreaterThan(0).Must(InvalidBookId).WithMessage("Invalid Book Id");
            RuleFor(x=>x.Price)
                .NotEmpty().GreaterThan(0);
            RuleFor(x => x.AvailableStores)
                .NotEmpty().Must(InvalidStoreIds).WithMessage("Invalid Stores");
            RuleFor(x => x.PublisherId)
                .NotEmpty().GreaterThan(0).Must(InvalidPublisherId).WithMessage("Invalid Publisher Id");

        }
        private bool InvalidBookId(int id)
        {
            bool value = true;
            if (!_context.Books.Any(x => x.Id == id))
            {
                value = false;
            }
            return value;
        }
        private bool InvalidPublisherId(int id)
        {
            bool value = true;
            if (!_context.Publishers.Any(x => x.Id == id))
            {
                value = false;
            }
            return value;
        }
        private bool InvalidStoreIds(IEnumerable<EditionStoreDto> ien)
        {
            bool value = true;
            foreach (EditionStoreDto dto in ien)
            {
                if (!_context.Stores.Any(x => x.Id == dto.StoreId))
                    value = false;
            }
            return value;
        }
    }
}
