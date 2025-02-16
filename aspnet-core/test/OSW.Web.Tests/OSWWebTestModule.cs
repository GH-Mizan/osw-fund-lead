using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OSW.EntityFrameworkCore;
using OSW.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace OSW.Web.Tests;

[DependsOn(
    typeof(OSWWebMvcModule),
    typeof(AbpAspNetCoreTestBaseModule)
)]
public class OSWWebTestModule : AbpModule
{
    public OSWWebTestModule(OSWEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
    }

    public override void PreInitialize()
    {
        Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(OSWWebTestModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        IocManager.Resolve<ApplicationPartManager>()
            .AddApplicationPartsIfNotAddedBefore(typeof(OSWWebMvcModule).Assembly);
    }
}