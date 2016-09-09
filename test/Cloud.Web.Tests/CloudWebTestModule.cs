using System.Reflection;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Cloud.Web.Startup;

namespace Cloud.Web.Tests
{
    [DependsOn(
        typeof(CloudWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class CloudWebTestModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}