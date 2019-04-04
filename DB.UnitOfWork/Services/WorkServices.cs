
using DB.Entity;
using DB.Entity.Assistance;
using DB.Entity.Workflow;
using DB.UnitOfWork.IServices;
using DB.Utils.Extend;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using static DB.Entity.Enum.WorkflowEnum;

namespace DB.UnitOfWork.Services
{

    public class WorkServices : IWorkServices
    {
        private BaseDbContext _context { get; set; }
        public WorkServices(BaseDbContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// 更新数据并且创建审批流数据
        /// </summary>
        /// <typeparam name="TEntity">继承WorkflowEntity的实体</typeparam>
        /// <param name="guid">数据ID</param>
        /// <param name="entityName">当前实体名称</param>
        /// <param name="message">留言内容</param>
        /// <returns>bool</returns>
        public bool GetEntityUpdate<TEntity>(Guid guid, string entityName, string message) where TEntity : WorkflowEntity, new()
        {
            Expression<Func<TEntity, bool>> where = LinqUtil.True<TEntity>();
            where = where.AndAlso(e => e.Id == guid || e.WorkflowStatus == WorkflowStatus.ApprovalNotSubmitted);
            var entity = _context.Set<TEntity>().AsNoTracking().FirstOrDefault(where);
            //更改待审核
            entity.WorkflowStatus = WorkflowStatus.ApprovalToBeAudited;
            entity.UpdateTime = DateTime.Now;
            var status = _context.Update(entity);
            if (status != null)
            {
                //创建工作流数据
                WorkflowApprovalInfoEntity workflowApprovalInfo = new WorkflowApprovalInfoEntity();
                workflowApprovalInfo.Id = Guid.NewGuid();
                workflowApprovalInfo.WorkflowStatus = WorkflowStatus.ApprovalToBeAudited;
                workflowApprovalInfo.EntityDataId = guid;
                workflowApprovalInfo.EntityName = entityName;
                workflowApprovalInfo.IsStatus = true;
                workflowApprovalInfo.Message = message;
                _context.Add(workflowApprovalInfo);
                return _context.SaveChanges() > 0 ? true : false;
            }
            else
            {
                return false;
            }
        }
    }
}
