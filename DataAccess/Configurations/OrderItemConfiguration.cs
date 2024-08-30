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
    internal class OrderItemConfiguration:EntityConfiguration<OrderItem>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Edition)
                .WithMany(x => x.ItemOrders)
                .HasForeignKey(x => x.EditionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
