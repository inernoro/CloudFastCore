using Abp.Application.Services.Dto;

namespace Cloud.TestApp
{
    public class TestAppService : CloudAppServiceBase, ITestAppService
    {
       

        public string Test(IdInput input)
        {
            return input.Id.ToString();
        }
    }
}