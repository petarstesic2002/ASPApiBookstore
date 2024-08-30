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
    public class EfCreateBook:EfUseCase,ICreateBook
    {
        public int Id => 6;
        public string Name => "Create Book";
        //private ASPContext Context;
        private CreateBookValidator _validator;
        public EfCreateBook(ASPContext context, CreateBookValidator validator):base(context)
        {
            _validator = validator;
        }
        public void Execute(CreateBookDto data)
        {
            _validator.ValidateAndThrow(data);
            Book b = new Book
            {
                AuthorId = data.AuthorId,
                Title = data.Title,
                Description=data.Description,
                PublicationYear = data.PublicationYear,
                Isbn = data.Isbn,
            };
            Context.Books.Add(b);
            Context.SaveChanges();
            int idB = b.Id; //last inserted
            List<BookGenre> lBg = new List<BookGenre>();
            foreach (int idG in data.GenreIds)
            {
                lBg.Add(new BookGenre
                {
                    BookId = idB,
                    GenreId = idG
                });
            }
            Context.BooksGenres.AddRange(lBg);
            Context.SaveChanges();
        }

    }
}
