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
    public class EfUpdateEdition:EfUseCase,IUpdateEdition
    {
        public int Id => 10;
        public string Name => "Update Edition";
        //private ASPContext Context;
        private UpdateEditionValidator _validator;
        public EfUpdateEdition(ASPContext context, UpdateEditionValidator validator) : base(context)
        {
            _validator = validator;
        }
        public void Execute(UpdateEditionDto data)
        {
            _validator.ValidateAndThrow(data);
            Edition e=Context.Editions.Where(x=>x.Id==data.Id).FirstOrDefault<Edition>();
            if (e != null)
            {
                e.PublisherId = data.PublisherId.HasValue ? data.PublisherId.Value : e.PublisherId;
                e.BookId = data.BookId.HasValue ? data.BookId.Value : e.BookId;
                e.ImageId = data.Image != null ? data.Image.Id : e.ImageId;
                Context.SaveChanges();
                if (data.Price.HasValue)
                {
                    Context.Prices.Add(new Price
                    {
                        EditionId = e.Id,
                        Value = data.Price.Value
                    });
                    Context.SaveChanges();
                }
                var currentStores=Context.StoresEditions.Where(x=>x.EditionId==e.Id).ToList();
                if (data.AvailableStores != null)
                {
                    List<StoreEdition> list = new List<StoreEdition>();
                    foreach (EditionStoreDto eds in data.AvailableStores)
                    {
                        if (!currentStores.Any(x => x.StoreId == eds.StoreId))
                        {
                            list.Add(new StoreEdition
                            {
                                EditionId = e.Id,
                                StoreId = eds.StoreId
                            });
                        }
                    }
                    Context.StoresEditions.AddRange(list);
                    Context.SaveChanges();
                }
                
            }
        }
    }
}
