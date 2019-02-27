using DB.Entity.Model;
using DB.IRepository.limit;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DB.UnitOfWork
{
    /// <summary>
    /// 工作流提交业务
    /// </summary>
    public class Workreflex
    {
        /// <summary>
        /// 根据实体反射提交工作流
        /// </summary>
        /// <param name="className">实体类</param>
        /// <param name="guid">数据ID</param>
        /// <returns></returns>
        public bool Establish(string className, Guid guid)
        {
            Type type = Type.GetType("DB.UnitOfWork.WorkEstablish." + className);
            MethodInfo[] methods = type.GetMethods();
            MethodInfo method = type.GetMethod("Establish", new Type[] { typeof(Guid) });
            object obj = Activator.CreateInstance(type);
            return (bool)method.Invoke(obj, new object[] { guid });
        }
    }
}
