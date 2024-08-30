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
    public class CreateOrderValidator:AbstractValidator<CreateOrderDto>
    {
        private readonly ASPContext _context;
        public CreateOrderValidator(ASPContext ctx)
        {
            _context = ctx;
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x=>x.OrderItems).NotEmpty().Must(InvalidOrderItems).WithMessage("Invalid Order Items");
            RuleFor(x=>x.UserId).NotEmpty().GreaterThan(0).Must(InvalidUserId).WithMessage("Invalid User Id");
        }
        private bool InvalidUserId(int id)
        {
            bool value = true;
            if (!_context.Users.Any(x => x.Id == id))
                value = false;
            return value;
        }
        private bool InvalidOrderItems(IEnumerable<OrderItemDto> items)
        {
            bool value = true;
            foreach (OrderItemDto dto in items)
            {
                if (!_context.Editions.Any(x => x.Id == dto.EditionId))
                    value = false;
                if (!_context.Prices.Any(x => x.Id == dto.PriceId))
                    value = false;
            }
            return value;
        }
    }
}
