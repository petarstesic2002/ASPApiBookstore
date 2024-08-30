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
    internal class WishlistConfiguration:EntityConfiguration<Wishlist>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Wishlist> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(x => x.UserEditions)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Edition)
                .WithMany(x => x.EditionUsers)
                .HasForeignKey(x => x.EditionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
