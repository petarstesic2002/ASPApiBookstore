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
    internal class CityConfiguration:EntityConfiguration<City>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.Name)
                  .HasMaxLength(50)
                  .IsRequired();
            builder.Property(x=>x.ZipCode)
                  .HasMaxLength(20)
                  .IsRequired();
            builder.HasIndex(x => x.Name)
                   .IsUnique();
            builder.HasMany(x => x.Stores)
                   .WithOne(x => x.City)
                   .HasForeignKey(x => x.CityId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Country)
                  .WithMany(x => x.Cities)
                  .HasForeignKey(x => x.CountryId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
