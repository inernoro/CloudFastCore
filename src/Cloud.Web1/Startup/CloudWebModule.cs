using System.Reflection;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Cloud.Configuration;
using Cloud.Dapper;
using Cloud.EntityFrameworkCore;
using Cloud.Mongo;
using Cloud.Redis;
using Cloud.Strategy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Cloud.Web.Startup
{
    [DependsOn(
        typeof(CloudStrategyModule),
        typeof(CloudRedisModule),
        typeof(CloudMongoModule), 
        typeof(CloudApplicationModule),
        typeof(CloudDapperModule),
        typeof(CloudEntityFrameworkCoreModule),
        typeof(AbpAspNetCoreModule))]
    public class CloudWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public CloudWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(CloudConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<CloudNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(CloudApplicationModule).Assembly
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}