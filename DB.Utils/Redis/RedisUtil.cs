using DB.Utils.Common;
using DB.Utils.Extend;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Collections.Generic;

namespace DB.Utils.Redis
{
    public class RedisUtil
    {
        private ConnectionMultiplexer redis { get; set; }
        public IConfiguration Configuration { get; }
        private IDatabase db { get; set; }
        private HttpContextUtil _httpContextUtil { get; set; }
        public RedisUtil(IConfiguration _configuration, HttpContextUtil httpContextUtil)
        {
            Configuration = _configuration;
            var s = Configuration.GetConnectionString("DataRedis");
            redis = ConnectionMultiplexer.Connect(s);
            db = redis.GetDatabase();
            this._httpContextUtil = httpContextUtil;
        }



        /// <summary>
        /// 存储List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetListValue<T>(string key, List<T> value) where T : class, new()
        {
            return db.StringSet(key, JsonNetHelper.SerializeObject(value));
        }

        /// <summary>
        /// 根据指定key的List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<T> GetListValue<T>(string key)
        {
            return JsonNetHelper.DeserializeObject<List<T>>(db.StringGet(key));
        }

        /// <summary>
        /// 存放对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetTValue<T>(string key, T value) where T : class, new()
        {
            return db.StringSet(key, JsonNetHelper.SerializeObject(value));
        }

        /// <summary>
        /// 根据Key获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetTVlues<T>(string key)
        {
            return JsonNetHelper.DeserializeObject<T>(db.StringGet(key));
        }

        /// <summary>
        /// 增加/修改
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetValue(string key, string value)
        {
            return db.StringSet(key, value);
        }

        /// <summary>
        /// 根据指定的Key查询
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            return db.StringGet(key);
        }

        /// <summary>
        /// 根据指定的Key删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool DeleteKey(string key)
        {
            return db.KeyDelete(key);
        }






        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetSessionUserNumber()
        {
            return _httpContextUtil.GetSession<string>(KeyUtil.user_Number);
        }

        /// <summary>
        /// Redis存放用户信息Key
        /// </summary>
        public string user()
        {
            return GetSessionUserNumber() + "aaad8f69-627e-4ede-b985-e40bdd2b78bc";
        }
        /// <summary>
        /// Redis存放角色信息Key
        /// </summary>
        public string role()
        {
            return GetSessionUserNumber() + "7df2304e-e162-4df5-b834-97aacca022eb";
        }
        /// <summary>
        /// Redis存放按钮关系信息Key
        /// </summary>
        public string rolebuttion()
        {
            return GetSessionUserNumber() + "f356393d-294b-43e4-a640-afd681a552c2";
        }
        /// <summary>
        /// Redis存放模块信息Kye
        /// </summary>
        public string module()
        {
            return GetSessionUserNumber() + "4c7f1c06-224d-4799-b49f-61a816986cff";
        }
    }
}
