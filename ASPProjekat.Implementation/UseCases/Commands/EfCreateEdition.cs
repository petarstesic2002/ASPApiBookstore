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
    public class EfCreateEdition:EfUseCase,ICreateEdition
    {
        public int Id => 7;
        public string Name => "Create Edition";
        //private ASPContext Context;
        private CreateEditionValidator _validator;
        public EfCreateEdition(ASPContext context,CreateEditionValidator validator):base(context)
        {
            _validator = validator;
        }
        public void Execute(CreateEditionDto data)
        {
            var img = data.Image!=null ? data.Image : Context.Images.Where(x=>x.Id==1).Select(x=>new ImageDto { Id=x.Id,Path=x.Path}).FirstOrDefault();
            _validator.ValidateAndThrow(data);
            Edition e = new Edition
            {
                BookId = data.BookId,
                ImageId = img.Id,
                PublisherId=data.PublisherId
            };
            Context.Editions.Add(e);
            Context.SaveChanges();
            int id=e.Id;
            Price p = new Price
            {
                EditionId = id,
                Value = data.Price
            };
            Context.Prices.Add(p);
            Context.SaveChanges();
            List<StoreEdition> storeEditions = new List<StoreEdition>();
            foreach(EditionStoreDto esd in data.AvailableStores)
            {
                storeEditions.Add(new StoreEdition
                {
                    EditionId = id,
                    StoreId = esd.StoreId
                });
            }
            Context.StoresEditions.AddRange(storeEditions);
            Context.SaveChanges();
        }
    }
}
