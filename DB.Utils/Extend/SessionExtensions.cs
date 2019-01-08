using DB.Utils.Common;
using Microsoft.AspNetCore.Http;

namespace DB.Utils.Extend
{
    /// <summary>
    /// 封装Session的扩展方法
    /// </summary>
    public static class SessionExtensions
    {
        /// <summary>
        /// 读取Session对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonNetHelper.DeserializeObject<T>(value);
        }

        /// <summary>
        /// 设置Session对象
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonNetHelper.SerializeObject(value));

        }
    }
}
