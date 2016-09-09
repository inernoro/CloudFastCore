using Cloud.Configuration;
using Cloud.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Cloud.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class CloudDbContextFactory : IDbContextFactory<CloudDbContext>
    {
        public CloudDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<CloudDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder, 
                configuration.GetConnectionString(CloudConsts.ConnectionStringName)
                );

            return new CloudDbContext(builder.Options);
        }
    }
}