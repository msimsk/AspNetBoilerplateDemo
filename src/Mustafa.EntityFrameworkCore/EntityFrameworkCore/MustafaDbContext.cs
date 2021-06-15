using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Mustafa.Authorization.Roles;
using Mustafa.Authorization.Users;
using Mustafa.MultiTenancy;
using Mustafa.Domain.Entities;
using Mustafa.Domain.Configurations;

namespace Mustafa.EntityFrameworkCore
{
    public class MustafaDbContext : AbpZeroDbContext<Tenant, Role, User, MustafaDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StockMove> StockMoves { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Unitline> Unitlines { get; set; }
        public DbSet<StockMoveType> StockMoveTypes { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        public MustafaDbContext(DbContextOptions<MustafaDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new ProductConfiguration())
                .ApplyConfiguration(new CategoryConfiguration())
                .ApplyConfiguration(new StockMoveConfiguration())
                .ApplyConfiguration(new VendorConfiguration())
                .ApplyConfiguration(new StockMoveTypeConfiguration())
                .ApplyConfiguration(new UnitlineConfiguration())
                .ApplyConfiguration(new WarehouseConfiguration());
        }
    }
}
