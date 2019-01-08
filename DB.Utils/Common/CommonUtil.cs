using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DB.Utils.Common
{
    /// <summary>
    /// 公共类，封装公共方法
    /// </summary>
    /// 修改记录：Brian 新增枚举方法
    public static class CommonUtil
    {
        /// <summary>
        /// 返回处理后的GUID，将
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 读取时间戳
        /// </summary>
        /// <returns></returns>
        public static long TimeSpan()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">待加密的字符串</param>
        /// <returns>返回加密后的字符串信息</returns>
        public static string Md5(string str)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// 把枚举转换为键值对集合
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="getText">以Enum为参数类型，String为返回类型的委托</param>
        /// <returns>以枚举值为key，枚举文本为value的键值对集合</returns>
        public static Dictionary<Int32, String> EnumToDictionary(Type enumType, Func<Enum, String> getText)
        {
            //if (!enumType.IsEnum)
            //{
            //    throw new ArgumentException("传入的参数必须是枚举类型！", "enumType");
            //}
            Dictionary<Int32, String> enumDic = new Dictionary<int, string>();
            Array enumValues = Enum.GetValues(enumType);
            foreach (Enum enumValue in enumValues)
            {
                Int32 key = Convert.ToInt32(enumValue);
                String value = getText(enumValue);
                enumDic.Add(key, value);
            }
            return enumDic;
        }

        /// <summary>
        /// 扩展方法，获得枚举的Description
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <param name="nameInstead">当枚举值没有定义DescriptionAttribute，是否使用枚举名代替，默认是使用</param>
        /// <returns>枚举的Description</returns>
        public static string GetDescription(this Enum value, Boolean nameInstead = true)
        {
            //Type type = value.GetType();
            //string name = Enum.GetName(type, value);
            //if (name == null)
            //{
            //    return null;
            //}

            //FieldInfo field = type.GetField(name);
            //DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            //if (attribute == null && nameInstead == true)
            //{
            //    return name;
            //}
            //return attribute == null ? null : attribute.Description;
            return "";
        }
    }
}
