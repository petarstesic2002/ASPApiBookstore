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
    internal class BookConfiguration:EntityConfiguration<Book>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Title)
                 .HasMaxLength(50)
                 .IsRequired();

            builder.Property(x => x.Isbn)
                 .HasMaxLength(50)
                 .IsRequired();

            builder.Property(x => x.Description)
                 .HasMaxLength(50)
                 .IsRequired();

            builder.Property(x => x.PublicationYear)
                 .HasMaxLength(4)
                 .IsRequired();

            builder.HasIndex(x => x.Isbn)
                   .IsUnique();

            builder.HasMany(x => x.BookGenres)
                   .WithOne(x => x.Book)
                   .HasForeignKey(x => x.BookId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Editions)
                   .WithOne(x => x.Book)
                   .HasForeignKey(x => x.BookId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
