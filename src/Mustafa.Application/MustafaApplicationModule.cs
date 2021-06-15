using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Mustafa.Authorization;
using Mustafa.Manager;

namespace Mustafa
{
    [DependsOn(
        typeof(MustafaCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MustafaApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MustafaAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MustafaApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                cfg => {
                    MapperManager.DtosToDomain(cfg);

                    // Scan the assembly for classes which inherit from AutoMapper.Profile
                    cfg.AddMaps(thisAssembly);
                });
        }
    }
}
