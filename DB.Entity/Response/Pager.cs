
namespace DB.Entity.Response
{
    /// <summary>
    /// 返回分页的信息的公共类
    /// </summary>
    /// 修改记录：
    public class Pager<T> where T : class
    {
        /// <summary>
        /// 总数
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 返回分页的实体集合
        /// </summary>
        public T rows { get; set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="total"></param>
        /// <param name="rows"></param>
        public Pager(int total, T rows)
        {
            this.total = total;
            this.rows = rows;
        }
    }
}
