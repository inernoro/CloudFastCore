﻿using System;
using System.Collections.Generic;
using Abp.Domain.Entities;
using Abp.Web.Models;
using Cloud.Framework.Assembly;
using Cloud.Framework.Mongo;
using Newtonsoft.Json.Linq;

namespace Cloud.Domain
{
    public class TestManager
    {

        /// <summary>
        /// 参数列表
        /// </summary>
        public Dictionary<string, string> Parament { get; set; }

        /// <summary>
        /// 请求方式
        /// </summary>
        public string CallType { get; set; }

        /// <summary>
        /// 测试环境
        /// </summary>
    //    public TestEnvironment TestEnvironment { set; get; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string DateType { get; set; }

        /// <summary>
        /// 链接类型
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// 是否需要登陆
        /// </summary>
        public bool IsLogin { get; set; }

        /// <summary>
        /// 调用状态
        /// </summary>
        public bool CallState { get; set; } = true;

        /// <summary>
        /// 返回结果集
        /// </summary>
        public AjaxResponse<object> Result { get; set; }

        /// <summary>
        /// 耗时
        /// </summary>
        public long Take { get; set; }

        /// <summary>
        /// 调用时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 调用者
        /// </summary>
        public long? UserId { get; set; }
    }

    public class AjaxResponse
    {
        public string Result { get; set; }
        public bool Success { get; set; }

        public static implicit operator AjaxResponse(AjaxResponse<object> v)
        {
            throw new NotImplementedException();
        }
    }
}