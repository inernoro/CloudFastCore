using System;
using System.Threading.Tasks;
using Abp.TestBase;
using Cloud.EntityFrameworkCore;
using Cloud.Tests.TestDatas;

namespace Cloud.Tests
{
    public class CloudTestBase : AbpIntegratedTestBase<CloudTestModule>
    {
        public CloudTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<CloudDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<CloudDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<CloudDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<CloudDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<CloudDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<CloudDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<CloudDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<CloudDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
