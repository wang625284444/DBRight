using DB.Entity.Assistance;
using System;

namespace DB.UnitOfWork.IServices
{
    
    public interface IWorkServices
    {
        /// <summary>
        /// 更新数据并且创建审批流数据
        /// </summary>
        /// <typeparam name="TEntity">继承WorkflowEntity的实体</typeparam>
        /// <param name="guid">数据ID</param>
        /// <param name="entityName">当前实体名称</param>
        /// <param name="message">留言内容</param>
        /// <returns>bool</returns>
        bool GetEntityUpdate<TEntity>(Guid guid, string entityName, string message) where TEntity : WorkflowEntity, new();
    }
}
