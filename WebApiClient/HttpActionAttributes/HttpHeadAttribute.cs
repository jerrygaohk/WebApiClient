﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient.Attributes
{
    /// <summary>
    /// 表示Head请求
    /// 不可继承
    /// </summary>
    public sealed class HttpHeadAttribute : HttpMethodAttribute
    {
        /// <summary>
        /// Head请求
        /// </summary>
        public HttpHeadAttribute()
            : base(HttpMethod.Head)
        {
        }

        /// <summary>
        /// Head请求
        /// </summary>
        /// <param name="path">相对路径</param>
        public HttpHeadAttribute(string path)
            : base(HttpMethod.Head, path)
        {
        }
    }
}
