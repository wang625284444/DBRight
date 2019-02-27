
using DB.Entity.Assistance;
using DB.Entity.Model;
using DB.Utils.Extend;
using System;
using System.Linq.Expressions;
using static DB.Entity.Enum.WorkflowEnum;

namespace DB.UnitOfWork
{

    public class WorkServices : IWorkServices
    {

        /// <summary>
        /// 更新提交的数据状态
        /// </summary>
        /// <param name="guid"></param>
        public void GetEntityUpdate<TEntity>(Guid guid) where TEntity : WorkflowEntity, new()
        {
            Expression<Func<TEntity, bool>> where = LinqUtil.True<TEntity>();
            where = where.AndAlso(e => e.Id == guid || e.WorkflowStatus == WorkflowStatus.ApprovalNotSubmitted);
        }
    }
}
