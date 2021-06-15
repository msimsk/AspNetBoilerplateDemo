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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(100);
            
            builder.Property(x => x.Descr)
                .HasColumnName("Descr")
                .HasMaxLength(1000);

            builder.HasMany<Product>(x => x.GetProducts)
                .WithOne(product => product.Category)
                .HasForeignKey(product => product.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
