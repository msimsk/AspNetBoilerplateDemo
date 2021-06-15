using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Mustafa.EntityFrameworkCore
{
    public static class MustafaDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MustafaDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MustafaDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
