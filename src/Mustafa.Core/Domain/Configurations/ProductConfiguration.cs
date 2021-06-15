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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(200);
            builder.Property(x => x.LastPrice).HasColumnType("float");
            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);
            builder.HasMany<StockMove>(x => x.GetStockMoves)
                .WithOne(stockMove => stockMove.Product)
                .HasForeignKey(stockMove => stockMove.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
