using ASPProjekat.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.DataAccess.Configurations
{
    internal class BookGenreConfiguration:EntityConfiguration<BookGenre>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<BookGenre> builder)
        {
            builder.HasOne(x => x.Book)
                .WithMany(x => x.BookGenres)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Genre)
                .WithMany(x => x.GenreBooks)
                .HasForeignKey(x => x.GenreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
