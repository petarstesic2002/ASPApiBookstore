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
    internal class CountryConfiguration : EntityConfiguration<Country>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Country> builder)
        {
            builder.Property(x => x.Name)
                  .HasMaxLength(50)
                  .IsRequired();

            builder.HasIndex(x => x.Name)
                   .IsUnique();

            builder.HasMany(x => x.Cities)
                   .WithOne(x => x.Country)
                   .HasForeignKey(x => x.CountryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
