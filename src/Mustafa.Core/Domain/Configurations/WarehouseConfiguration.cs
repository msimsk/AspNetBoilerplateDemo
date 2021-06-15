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
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.ToTable("Warehouse");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(100);
            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasMany<StockMove>(x => x.GetStockMove)
                .WithOne(stockmove => stockmove.Warehouse)
                .HasForeignKey(stockmove => stockmove.WarehouseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
