using ASPProjekat.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ASPProjekat.DataAccess.Configurations
{
    internal class StoreConfiguration:EntityConfiguration<Store>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Store> builder)
        {
            builder.Property(x=>x.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasOne(x => x.City)
                .WithMany(x => x.Stores)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
