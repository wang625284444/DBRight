using DB.Utils.Common;
using DB.Utils.Resource;
using System.Collections.Generic;

namespace DB.Entity.Response
{
    /// <summary>
    /// 封装返回的实体集合，前台ajax请求返回固定格式
    /// </summary>
    /// 修改记录：
    public class BaseResult<T>
    {
        /// <summary>
        /// 状态
        /// </summary>
        public bool status_Type { get; set; }
        /// <summary>
        /// 状态码
        /// </summary>
        public int status_code { get; set; }

        /// <summary>
        /// 状态信息
        /// </summary>
        public string status_message { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public long timestamp { get; set; }

        /// <summary>
        /// 返回的数据
        /// </summary>
        public T data { get; set; }

        public List<T> dataList { get; set; }

        /// <summary>
        /// 构造函数返回方法
        /// </summary>
        public BaseResult()
        {
            this.timestamp = CommonUtil.TimeSpan();
        }

        /// <summary>
        /// 构造函数返回方法
        /// </summary>
        /// <param name="data"></param>
        public BaseResult(T data)
        {
            this.timestamp = CommonUtil.TimeSpan();
            this.status_Type = data == null ? false : true;
            this.status_code = data == null ? 202 : 200;
            this.status_message = SystemUtil.getMessage(status_code);
            this.data = data;
        }

        /// <summary>
        /// 返回处理是否成功
        /// </summary>
        /// <param name="statusType"></param>
        public BaseResult(bool statusType)
        {
            this.timestamp = CommonUtil.TimeSpan();
            this.status_Type = statusType;
            this.data = default(T);
            if (statusType) this.status_message = "成功"; else this.status_message = "失败";
        }

        /// <summary>
        /// 构造函数返回方法
        /// </summary>
        /// <param name="message"></param>
        public BaseResult(string message, bool statusType = true)
        {
            this.timestamp = CommonUtil.TimeSpan();
            this.status_code = status_code;
            this.data = default(T);
            this.status_message = message;
            this.status_Type = statusType;
        }

        public BaseResult(string message, List<T> data)
        {
            this.timestamp = CommonUtil.TimeSpan();
            this.status_code = status_code;
            this.dataList = data;
            this.status_message = "";
        }

        /// <summary>
        /// 构造函数返回方法
        /// </summary>
        /// <param name="status_code"></param>
        /// <param name="data"></param>
        public BaseResult(int status_code, T data)
        {
            this.timestamp = CommonUtil.TimeSpan();
            this.status_code = status_code;
            this.data = data;
            this.status_message = SystemUtil.getMessage(status_code);
        }

        /// <summary>
        /// 构造函数返回方法
        /// </summary>
        /// <param name="status_code"></param>
        /// <param name="data"></param>
        public BaseResult(int status_code, string status_message, T data)
        {
            this.timestamp = CommonUtil.TimeSpan();
            this.status_code = status_code;
            this.data = data;
            this.status_message = status_message;
        }
    }
}
