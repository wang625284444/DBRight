using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Utils.Common
{
    public class RemoveUtil<T>
    {

        /// <summary>
        /// 删除list集合中的一条数据
        /// </summary>
        /// <param name="list">数据集合</param>
        /// <param name="index">删除第几条</param>
        /// <returns></returns>
        public List<T> RemoveAt(List<T> list,int index)
        {

            if (list.Count != 0)
            {
                list.RemoveAt(index);
            }
            return list;
        }

        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="list">list集合</param>
        /// <param name="match">lambda条件</param>
        /// <returns></returns>
        public List<T> RemoveAll(List<T> list, Predicate<T> match)
        {
            //检查数据集合是否为空
            if (list.Count != 0)
            {
                //根据条件删除数据
                list.RemoveAll(match);
            }
            return list;
        }

        /// <summary>
        /// 在一定范围删除一条数据
        /// </summary>
        /// <param name="list">数据集合</param>
        /// <param name="index">删除第几条</param>
        /// <param name="count">总共条数</param>
        /// <returns></returns>
        public List<T> RemoveRange(List<T> list, int index, int count)
        {
            //检查数据集合是否为空
            if (list.Count != 0)
            {
                //根据条件删除数据
                list.RemoveRange(index, count);
            }
            return list;
        }
    }
}
