using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OSW.Configuration;
using OSW.EntityFrameworkCore;
using OSW.Migrator.DependencyInjection;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace OSW.Migrator;

[DependsOn(typeof(OSWEntityFrameworkModule))]
public class OSWMigratorModule : AbpModule
{
    private readonly IConfigurationRoot _appConfiguration;

    public OSWMigratorModule(OSWEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

        _appConfiguration = AppConfigurations.Get(
            typeof(OSWMigratorModule).GetAssembly().GetDirectoryPathOrNull()
        );
    }

    public override void PreInitialize()
    {
        Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            OSWConsts.ConnectionStringName
        );

        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        Configuration.ReplaceService(
            typeof(IEventBus),
            () => IocManager.IocContainer.Register(
                Component.For<IEventBus>().Instance(NullEventBus.Instance)
            )
        );
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(OSWMigratorModule).GetAssembly());
        ServiceCollectionRegistrar.Register(IocManager);
    }
}
