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
    internal class EditionConfiguration:EntityConfiguration<Edition>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Edition> builder)
        {

            builder.HasMany(x => x.Prices)
                   .WithOne(x => x.Edition)
                   .HasForeignKey(x => x.EditionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.EditionUsers)
                   .WithOne(x => x.Edition)
                   .HasForeignKey(x => x.EditionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.ItemOrders)
                   .WithOne(x => x.Edition)
                   .HasForeignKey(x => x.EditionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.EditionStores)
                   .WithOne(x => x.Edition)
                   .HasForeignKey(x => x.EditionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Prices)
                   .WithOne(x => x.Edition)
                   .HasForeignKey(x => x.EditionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Book)
                .WithMany(x => x.Editions)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Publisher)
                .WithMany(x => x.Editions)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Image)
                .WithMany(x=> x.Editions)
                .HasForeignKey(x=>x.ImageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
