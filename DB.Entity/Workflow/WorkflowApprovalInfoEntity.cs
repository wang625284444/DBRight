using DB.Entity.Assistance;
using System;
using static DB.Entity.Enum.WorkflowEnum;

namespace DB.Entity.Workflow
{
    /// <summary>
    /// 工作流数据提交
    /// </summary>
    public class WorkflowApprovalInfoEntity: AssistanceEntity
    {
        /// <summary>
        /// 实体数据ID
        /// </summary>
        public Guid EntityDataId { get; set; }
        /// <summary>
        /// 当前数据状态
        /// </summary>
        public WorkflowStatus WorkflowStatus { get; set; }
        /// <summary>
        /// 实体名称
        /// </summary>
        public string EntityName { get; set; }
        /// <summary>
        /// 提交留言
        /// </summary>
        public string Message { get; set; }
    }
}
