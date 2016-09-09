using System.Reflection;
using Abp.Modules;
using Cloud.Framework.Assembly;

namespace Cloud.Strategy
{
    [DependsOn(typeof(CloudCoreModule))]

    public class CloudStrategyModule : AbpModule
    { 
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            CloudConfigurage.StartInitializationType();
        }
    }
}
