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
    internal class PublisherConfiguration:EntityConfiguration<Publisher>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Publisher> builder)
        {
            builder.Property(x => x.Name)
                  .HasMaxLength(50)
                  .IsRequired();

            builder.HasIndex(x => x.Name)
                   .IsUnique();

            builder.HasMany(x => x.Editions)
                   .WithOne(x => x.Publisher)
                   .HasForeignKey(x => x.PublisherId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
