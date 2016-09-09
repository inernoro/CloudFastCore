using System.Collections.Generic;
using System.Threading.Tasks; 
using Abp.Application.Services;

namespace Cloud.ApiManager.CodeBuild
{
    public interface ICodeBuildAppService : IApplicationService
    { 
        void BuildCode(string tableName); 
         
        Dictionary<string, string> BuilDictionary(string tableName);
    }
}