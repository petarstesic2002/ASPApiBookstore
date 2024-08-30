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
    internal class StoreEditionConfiguration:EntityConfiguration<StoreEdition>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<StoreEdition> builder)
        {
            builder.HasOne(x => x.Edition)
                .WithMany(x => x.EditionStores)
                .HasForeignKey(x => x.EditionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Store)
                .WithMany(x => x.StoreEditions)
                .HasForeignKey(x => x.StoreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
