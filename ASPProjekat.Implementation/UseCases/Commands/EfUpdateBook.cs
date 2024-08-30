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
    public class EfUpdateBook:EfUseCase,IUpdateBook
    {
        public int Id => 9;
        public string Name => "Update Book";
        //private ASPContext Context;
        private UpdateBookValidator _validator;
        public EfUpdateBook(ASPContext context,UpdateBookValidator validator):base(context)
        {
            _validator = validator;
        }
        public void Execute(UpdateBookDto data)
        {
            
            _validator.ValidateAndThrow(data);
            Book b=Context.Books.Where(x=>x.Id==data.Id).FirstOrDefault<Book>();
            if (b!=null)
            {
                b.AuthorId = data.AuthorId.HasValue ? data.AuthorId.Value : b.AuthorId;
                b.PublicationYear= string.IsNullOrEmpty(data.PublicationYear) ? data.PublicationYear : b.PublicationYear;
                b.Isbn= string.IsNullOrEmpty(data.Isbn) ? data.Isbn : b.Isbn;
                b.Title = string.IsNullOrEmpty(data.Title) ? data.Title : b.Title;
                b.Description = string.IsNullOrEmpty(data.Description) ? data.Description : b.Description;
                Context.SaveChanges();
            }
            var currentBookGenres=Context.BooksGenres.Where(x=>x.BookId==b.Id).ToList();
            if (data.GenreIds!=null&&data.GenreIds.Any())
            {
                List<BookGenre> bookGenres = new List<BookGenre>();
                foreach(int gId in data.GenreIds)
                {
                    if (!currentBookGenres.Any(x => x.GenreId == gId))
                    {
                        bookGenres.Add(new BookGenre
                        {
                            GenreId = gId,
                            BookId = b.Id
                        });
                    }
                }
                if (bookGenres.Count > 0)
                {
                    Context.BooksGenres.AddRange(bookGenres);
                    Context.SaveChanges();
                }
            }
        }
    }
}
