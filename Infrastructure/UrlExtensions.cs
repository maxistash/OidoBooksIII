using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assign5.Infrastructure
{
    public static class UrlExtensions
    {
        //
        public static string PathandQuery(this HttpRequest request) =>
            // if this request.QueryString.HasValue has a value then return the string below, otherwise do what is written after the colon
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
