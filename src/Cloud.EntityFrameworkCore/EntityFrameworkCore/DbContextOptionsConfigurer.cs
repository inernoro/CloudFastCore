using Microsoft.EntityFrameworkCore;

namespace Cloud.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<CloudDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for CloudDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
