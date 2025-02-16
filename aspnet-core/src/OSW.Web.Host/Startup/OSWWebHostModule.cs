using Abp.Modules;
using Abp.Reflection.Extensions;
using OSW.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace OSW.Web.Host.Startup
{
    [DependsOn(
       typeof(OSWWebCoreModule))]
    public class OSWWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public OSWWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OSWWebHostModule).GetAssembly());
        }
    }
}
