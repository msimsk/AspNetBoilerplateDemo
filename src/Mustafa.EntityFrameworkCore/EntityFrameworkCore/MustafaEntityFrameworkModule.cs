using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mustafa.EntityFrameworkCore.Seed;

namespace Mustafa.EntityFrameworkCore
{
    [DependsOn(
        typeof(MustafaCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class MustafaEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {

                Configuration.Modules.AbpEfCore().AddDbContext<MustafaDbContext>(options =>
                {
                    options.DbContextOptions.UseLazyLoadingProxies();
                    if (options.ExistingConnection != null)
                    {
                        MustafaDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        MustafaDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MustafaEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
