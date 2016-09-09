using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace Cloud
{
    [DependsOn(
        typeof(CloudCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class CloudApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}