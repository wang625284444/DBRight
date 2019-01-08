using Microsoft.AspNetCore.Http;

namespace DB.Utils.Extend
{
    /// <summary>
    /// HttpContext对象封装
    /// </summary>
    public class HttpContextUtil
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        private ISession session => httpContextAccessor.HttpContext.Session;
        
        private ConnectionInfo connectionInfo => httpContextAccessor.HttpContext.Connection;
        public HttpContextUtil(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }

        public string getRemoteIp()
        {
            return connectionInfo.LocalIpAddress.ToString();
        }
        /// <summary>
        /// 读取session对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetObjectAsJson<T>(string key)
        {
            return session.Get<T>(key);
        }
        /// <summary>
        /// 设置session对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void setObjectAsJson<T>(string key, T value)
        {
            session.Set(key, value);
        }
        /// <summary>
        /// 清除session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        public void removeObjectAsJson(string key)
        {
            session.Remove(key);
        }
    }
}
