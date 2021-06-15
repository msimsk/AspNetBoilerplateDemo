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
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.ToTable("Vendor");

            //builder.Property(x => x.Id)

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(100);
            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);
            builder.HasMany<StockMove>(x => x.GetStockMove)
               .WithOne(stockMove => stockMove.Vendor)
               .HasForeignKey(stockMove => stockMove.VendorId)
               .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
