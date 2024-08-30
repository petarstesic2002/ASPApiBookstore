using ASPProjekat.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.DataAccess.Configurations
{
    internal class GenreConfiguration:EntityConfiguration<Genre>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(x => x.Name)
                  .HasMaxLength(30)
                  .IsRequired();

            builder.HasIndex(x => x.Name)
                   .IsUnique();

            builder.HasMany(x => x.GenreBooks)
                   .WithOne(x => x.Genre)
                   .HasForeignKey(x => x.GenreId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
