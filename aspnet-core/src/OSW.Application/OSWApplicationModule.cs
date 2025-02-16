using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OSW.Authorization;

namespace OSW;

[DependsOn(
    typeof(OSWCoreModule),
    typeof(AbpAutoMapperModule))]
public class OSWApplicationModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.Authorization.Providers.Add<OSWAuthorizationProvider>();
    }

    public override void Initialize()
    {
        var thisAssembly = typeof(OSWApplicationModule).GetAssembly();

        IocManager.RegisterAssemblyByConvention(thisAssembly);

        Configuration.Modules.AbpAutoMapper().Configurators.Add(
            // Scan the assembly for classes which inherit from AutoMapper.Profile
            cfg => cfg.AddMaps(thisAssembly)
        );
    }
}
