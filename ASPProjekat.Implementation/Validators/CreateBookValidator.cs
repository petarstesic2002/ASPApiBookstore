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
    public class CreateBookValidator:AbstractValidator<CreateBookDto>
    {
        private readonly ASPContext _context;
        public CreateBookValidator(ASPContext ctx)
        {
            _context = ctx;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Title)
                .NotEmpty().MinimumLength(2);
            RuleFor(x => x.Description).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Isbn).NotEmpty().MinimumLength(2);
            RuleFor(x => x.AuthorId).NotEmpty().GreaterThan(0).Must(InvalidAuthorId).WithMessage("Invalid Author Id");
            RuleFor(x => x.PublicationYear).NotEmpty().MaximumLength(4);
            RuleFor(x => x.GenreIds).NotEmpty().Must(InvalidGenreIds).WithMessage("Invalid Genre Ids");

        }
        private bool InvalidGenreIds(IEnumerable<int> genreIds)
        {
            bool value = true;
            foreach (int id in genreIds)
            {
                if (!_context.Genres.Any(x => x.Id == id))
                    value = false;
            }
            return value;
        }
        private bool InvalidAuthorId(int id)
        {
            bool value = true;
            if(!_context.Authors.Any(x => x.Id == id))
            {
                value = false;
            }
            return value;
        }
    }
}
