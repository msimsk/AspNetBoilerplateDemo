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
    public class StockMoveTypeConfiguration : IEntityTypeConfiguration<StockMoveType>
    {
        public void Configure(EntityTypeBuilder<StockMoveType> builder)
        {
            builder.ToTable("StockMoveType");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TYPE)
                .HasColumnName("TYPE")
                .HasMaxLength(100);


            builder.HasMany<StockMove>(x => x.GetStockMove)
                .WithOne(stockmove => stockmove.StockMoveType)
                .HasForeignKey(stockmove => stockmove.StockMoveTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
