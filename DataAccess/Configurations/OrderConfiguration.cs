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
    internal class OrderConfiguration:EntityConfiguration<Order>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(x => x.User)
                 .WithMany(x => x.Orders)
                 .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x=>x.OrderItems)
                .WithOne(x=>x.Order)
                .HasForeignKey(x=>x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
