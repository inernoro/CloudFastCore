using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cloud.EntityFrameworkCore
{
    public class CloudDbContext : AbpDbContext
    {
        public CloudDbContext(DbContextOptions<CloudDbContext> options) 
            : base(options)
        {

        }
    }
}
