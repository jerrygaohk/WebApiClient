﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApiClient.Contexts;

namespace WebApiClient.Attributes
{
    /// <summary>
    /// 表示http请求方法描述特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class HttpMethodAttribute : ApiActionAttribute
    {
        /// <summary>
        /// 获取请求方法
        /// </summary>
        public HttpMethod Method { get; private set; }

        /// <summary>
        /// 获取请求相对路径
        /// </summary>
        public string Path { get; private set; }


        /// <summary>
        /// http请求方法描述特性
        /// </summary>
        /// <param name="method">请求方法</param>
        public HttpMethodAttribute(HttpMethod method)
            : this(method, null)
        {
        }

        /// <summary>
        /// http请求方法描述特性
        /// </summary>
        /// <param name="method">请求方法</param>
        /// <param name="path">请求相对路径</param>
        public HttpMethodAttribute(HttpMethod method, string path)
        {
            this.Method = method;
            this.Path = path;
        }

        /// <summary>
        /// 执行前
        /// </summary>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        public override Task BeforeRequestAsync(ApiActionContext context)
        {
            context.RequestMessage.Method = this.Method;
            if (string.IsNullOrEmpty(this.Path) == false)
            {
                var baseUrl = context.RequestMessage.RequestUri;
                context.RequestMessage.RequestUri = new Uri(baseUrl, this.Path);
            }
            return TaskExtend.CompletedTask;
        }

        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1}", this.Method, this.Path);
        }
    }
}
