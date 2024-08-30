using ASPProjekat.ApplicationLayer.Commands;
using ASPProjekat.ApplicationLayer.DTO;
using ASPProjekat.DataAccess;
using ASPProjekat.DomainLayer.Entities;
using ASPProjekat.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Commands
{
    public class EfCreateOrder:EfUseCase,ICreateOrder
    {
        public int Id => 3;
        public string Name => "Create Orders";
        //private ASPContext Context;
        private CreateOrderValidator _validator;
        public EfCreateOrder(ASPContext context, CreateOrderValidator validator) : base(context)
        {
            _validator = validator;
        }
        public void Execute(CreateOrderDto data)
        {
            _validator.ValidateAndThrow(data);
            Order o = new Order
            {
                UserId = data.UserId
            };
            Context.Orders.Add(o);
            Context.SaveChanges();
            int id = o.Id;
            List<OrderItem> items = new List<OrderItem>();
            foreach(OrderItemDto item in data.OrderItems)
            {
                items.Add(new OrderItem
                {
                    OrderId = id,
                    EditionId = item.EditionId,
                    PriceId = item.PriceId,
                    Quantity = item.Quantity
                });
            }
            Context.OrderItems.AddRange(items);
            Context.SaveChanges();
            
        }
    }
}
