using ASPProjekat.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.DataAccess.Configurations
{
    internal class PriceConfiguration:EntityConfiguration<Price>
    {
        protected override void ConfigureEntity(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Price> builder)
        {
            builder.HasOne(x => x.Edition)
                .WithMany(x => x.Prices)
                .HasForeignKey(x => x.EditionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Value).IsRequired();

            builder.HasMany(x=>x.OrderItems)
                .WithOne(x=>x.Price)
                .HasForeignKey(x=>x.PriceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
