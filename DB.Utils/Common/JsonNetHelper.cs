using Newtonsoft.Json;
using System;

namespace DB.Utils.Common
{
    /// <summary>
    /// Json.NET,JavaScript两种类型对Json串的操作
    /// 使用： var Demo = JsonNet.JsonNetDeserializeToString<Demo />(string inserted);
    /// </summary>
    public static class JsonNetHelper
    {
        /// <summary>
        /// 将实体对象转换为Json对象，生成字符串
        /// </summary>
        /// <param name="item">实体对象</param>
        /// <returns></returns>
        public static string SerializeObject(object item)
        {
            try
            {
                return JsonConvert.SerializeObject(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }





        /// <summary>
        /// 将Json串对象解析成固定的对象信息
        /// </summary>
        /// <typeparam name="T">需要得到解析后对象的实体类型</typeparam>
        /// <param name="jsonStr">json串</param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string jsonStr)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonStr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
