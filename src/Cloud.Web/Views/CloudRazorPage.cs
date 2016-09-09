using Abp.AspNetCore.Mvc.Views;

namespace Cloud.Web.Views
{
    public abstract class CloudRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected CloudRazorPage()
        {
            LocalizationSourceName = CloudConsts.LocalizationSourceName;
        }
    }
}
