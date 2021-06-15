using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Mustafa.Configuration;
using Abp.Hangfire.Configuration;

namespace Mustafa.Web.Host.Startup
{
    [DependsOn(
       typeof(MustafaWebCoreModule))]
    public class MustafaWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MustafaWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MustafaWebHostModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            Configuration.BackgroundJobs.UseHangfire();
        }
    }
}
