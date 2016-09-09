using System.Reflection;
using Abp.EntityFrameworkCore;
using Abp.Modules;

namespace Cloud.EntityFrameworkCore
{
    [DependsOn(
        typeof(CloudCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class CloudEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}