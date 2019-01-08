using DB.Utils.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;

namespace DB.Utils.Extend
{
    public static class CookiesExtensions

    {
        private static HttpContext httpContext;
        /// <summary>
        /// 写入cookie
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="minutes"></param>
        internal static void Set<T>(IResponseCookies responseCookies, string key, T value, int minutes)
        {
            responseCookies.Append(key, JsonNetHelper.SerializeObject(value), new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(minutes)
            });
        }
        internal static void Deleete(IResponseCookies responseCookies, string key)
        {
            responseCookies.Delete(key);
        }

        internal static string Get(this IRequestCookiesFeature cookies, string key)
        {
            cookies.Cookies.TryGetValue(key, out string value);
            if (string.IsNullOrEmpty(value))
                value = string.Empty;
            return value;
        }


        /// <summary>
        /// 设置本地cookie
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>  
        /// <param name="minutes">过期时长，单位：分钟</param>      
        internal static void SetCookies<T>(this IRequestCookiesFeature requestCookiesFeature,string key, T value, int minutes = 30)
        {
            httpContext.Response.Cookies.Append(key, JsonNetHelper.SerializeObject(value), new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(minutes)
            });
        }
    }
}
