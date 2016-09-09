using System.Diagnostics;
using Abp.Application.Services;
using Abp.Dependency;
using Abp.UI;
using Cloud.Framework.Script;

namespace Cloud
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class CloudAppServiceBase : ApplicationService
    {
        protected CloudAppServiceBase()
        {
            LocalizationSourceName = CloudConsts.LocalizationSourceName;
        }
        private static ILuaAssembly Dynamic => IocManager.Instance.Resolve<ILuaAssembly>();


        public dynamic Physics
        {
            get
            {
                var basetype = GetType().BaseType.FullName;
                if (basetype != null) return Dynamic.NamespaceGetValue(basetype);
                throw new UserFriendlyException("BaseType Is Null");
            }
        }

        public dynamic Current
        {
            get
            {
                var dy = new StackTrace().GetFrame(1).GetMethod().Name;
                return Physics[dy];
            }
        }

    }
}