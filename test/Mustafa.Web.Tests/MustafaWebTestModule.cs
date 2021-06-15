using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Mustafa.EntityFrameworkCore;
using Mustafa.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Mustafa.Web.Tests
{
    [DependsOn(
        typeof(MustafaWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MustafaWebTestModule : AbpModule
    {
        public MustafaWebTestModule(MustafaEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MustafaWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MustafaWebMvcModule).Assembly);
        }
    }
}