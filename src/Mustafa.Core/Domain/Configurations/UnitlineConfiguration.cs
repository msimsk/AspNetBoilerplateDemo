using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mustafa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Domain.Configurations
{
    public class UnitlineConfiguration : IEntityTypeConfiguration<Unitline>
    {
        public void Configure(EntityTypeBuilder<Unitline> builder)
        {
            builder.ToTable("Unitline");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UnitType)
                .HasColumnName("UnitType")
                .HasMaxLength(100);
            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);
            builder.HasMany<Product>(x => x.GetProducts)
                .WithOne(product => product.Unitline)
                .HasForeignKey(product => product.UnitlineId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
