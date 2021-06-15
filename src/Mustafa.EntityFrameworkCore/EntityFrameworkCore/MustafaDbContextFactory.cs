using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Mustafa.Configuration;
using Mustafa.Web;

namespace Mustafa.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MustafaDbContextFactory : IDesignTimeDbContextFactory<MustafaDbContext>
    {
        public MustafaDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MustafaDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            builder.UseLazyLoadingProxies();

            MustafaDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MustafaConsts.ConnectionStringName));

            return new MustafaDbContext(builder.Options);
        }
    }
}
