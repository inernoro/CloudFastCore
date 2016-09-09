using System;
using System.Collections.Generic;
using System.Net;
using Abp.Dependency;
using Cloud.Domain;
using Newtonsoft.Json;
using Abp.Extensions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Cloud.Framework.Cache.Redis;

namespace Cloud.Framework.Assembly
{
    public static class Network
    {

        private static Func<Login> _loginFunc;
        private static Func<string> _getguidFunc;
        private static Action<string> _writeCookieAction;
        private static readonly Dictionary<string, CookieContainer> Dictionary = new Dictionary<string, CookieContainer>();

        static Network()
        {
            var redis = IocManager.Instance.Resolve<IRedisHelper>();
            var user = IocManager.Instance.Resolve<ICurrentUser>();
            _loginFunc = () => new Login { UserName = user.UserName, Password = user.Password };
            _getguidFunc = () => user.Token;
        }

        #region Http请求


        

        /// <summary>
        /// 调用前初始化此方法
        /// </summary>
        /// <param name="func"></param>
        public static void InitGetUserNameAndPassword(Func<Login> func)
        {
            _loginFunc = func;
        }

        /// <summary>
        /// 调用前初始化此方法
        /// </summary>
        /// <param name="func"></param>
        public static void InitGetGuid(Func<string> func)
        {
            _getguidFunc = func;
        }

        /// <summary>
        /// 调用写入Cookie的方法
        /// </summary>
        /// <param name="action"></param>
        public static void InitWriteCookie(Action<string> action)
        {
            _writeCookieAction = action;
        }


        #endregion

        #region CookieBase 

        
        #endregion

        #region CookieBaseNotLogin

        /// <summary>
        /// HttpClient实现Post请求
        /// </summary>
        public static Task<string> DoPost(string url, string parament)
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            using (var http = new HttpClient(handler))
            {
                HttpContent content = new StringContent(parament);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = http.PostAsync(url, content).Result;
                response.EnsureSuccessStatusCode();
                var resultValue = response.Content.ReadAsStringAsync();
                return resultValue;
            }
        }

        /// <summary>
        /// HttpClient实现Get请求
        /// </summary>
        public static Task<string> DoGet(string url, IEnumerable<KeyValuePair<string, string>> dictionary = null)
        {
            if (dictionary == null)
                dictionary = new Dictionary<string, string>();
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            using (var http = new HttpClient(handler))
            {
                var content = new FormUrlEncodedContent(dictionary);
                var getMessage = http.GetAsync(url);
                getMessage.Wait();
                var response = getMessage.Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync();
            }
        }

        public static T DoGet<T>(string initUrl)
        {
            throw new NotImplementedException();
        }

        #endregion
    }


    public class Login
    {
        public Login()
        {
            var url = IocManager.Instance.Resolve<IManagerUrlStrategy>();
            LoginUrl = url.LoginUrl;
        }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string LoginUrl { get; }
    }
}