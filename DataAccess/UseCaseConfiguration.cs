using ASPProjekat.DataAccess.Configurations;
using ASPProjekat.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.DataAccess
{
    public class UseCaseConfiguration : EntityConfiguration<UseCase>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<UseCase> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x=>x.UseCaseLogs)
                .WithOne(x=>x.UseCase)
                .HasForeignKey(x=>x.UseCaseId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.HasMany(x => x.UseCaseRoles)
                .WithOne(x => x.UseCase)
                .HasForeignKey(x => x.UseCaseId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

        }
    }
}
