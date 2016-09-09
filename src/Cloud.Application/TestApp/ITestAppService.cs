using Abp.Application.Services;
using Abp.Application.Services.Dto; 

namespace Cloud.TestApp
{
    public interface ITestAppService : IApplicationService
    {  
        string Test(IdInput input);
    }
}