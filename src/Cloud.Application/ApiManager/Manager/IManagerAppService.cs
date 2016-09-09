using System.Collections.Generic;
using System.Threading.Tasks; 
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Cloud.ApiManager.Manager.Dtos;
using Cloud.Framework.Assembly;
using Cloud.Framework.Mongo;

namespace Cloud.ApiManager.Manager
{
    public interface IManagerAppService : IApplicationService
    {
        [ContentDisplay("获取最新")]
        Task<ListResultOutput<GetOutput>> GetBatch();
         
        ViewDataMongoModel AllInterface();
         
        ListResultOutput<OpenDocumentResponse> Interface(string actionName);
         
        List<NamespaceDto> GetNamespace();
         
        OpenDocumentResponse GetInfo(string input);


        Task<TestOutput> Test(TestInput input);

        [ContentDisplay("动态Js")] 
        Task<string> CloudHelper();

    }
}