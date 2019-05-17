
namespace DB.Entity.Response
{
    /// <summary>
    /// 返回分页的信息的公共类
    /// </summary>
    /// 修改记录：
    public class Pager<T> where T : class
    {
        /// <summary>
        /// 数据状态码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 输出信息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// 返回分页的实体集合
        /// </summary>
        public T data { get; set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="count"></param>
        /// <param name="data"></param>
        public Pager(int count, T data)
        {
            this.count = count;
            this.data = data;
        }

        public Pager(int code, string msg, int count, T data) {
            this.code = code;
            this.msg = msg;
            this.count = count;
            this.data = data;
        }
    }
}
