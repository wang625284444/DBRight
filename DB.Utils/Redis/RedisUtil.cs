﻿using DB.Utils.Common;
using DB.Utils.Extend;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
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
        public List<T> GetListValue<T>(string key) where T : class
        {
            if (db.StringGet(key).IsNull == true)
            {
                return null;
            }
            else
            {
                return JsonNetHelper.DeserializeObject<List<T>>(db.StringGet(key));
            }
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
        public T GetTVlues<T>(string key) where T : class
        {
            if (db.StringGet(key).IsNull == true)
            {
                return null;
            }
            else
            {
                return JsonNetHelper.DeserializeObject<T>(db.StringGet(key));
            }
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



        public string UserRole(Guid guid)
        {
            return "UserRole-" + guid.ToString();
        }


        /// <summary>
        /// Redis存放角色信息Key
        /// </summary>
        public string Role(Guid guid)
        {
            return "Role-" + guid.ToString();
        }
        /// <summary>
        /// Redis存放按钮关系信息Key
        /// </summary>
        public string RoleButtion(Guid guid)
        {
            return "RoleButtion-" + guid.ToString();
        }
        /// <summary>
        /// Redis存放模块信息Kye
        /// </summary>
        public string Module(Guid guid)
        {
            return "Module-" + guid;
        }
    }
}
