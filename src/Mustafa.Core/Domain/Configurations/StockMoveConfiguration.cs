using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mustafa.Domain.Entities;

namespace Mustafa.Domain.Configurations
{
    public class StockMoveConfiguration : IEntityTypeConfiguration<StockMove>
    {
        public void Configure(EntityTypeBuilder<StockMove> builder)
        {
            builder.ToTable("StockMove");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.Quantity).HasColumnType("float");
            builder.Property(x => x.UnitPrice).HasColumnType("float");

            builder.Property(x => x.Descr)
                .HasColumnName("Descr")
                .HasMaxLength(1000);
        }
    }
}
