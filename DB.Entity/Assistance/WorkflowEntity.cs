using System;
using static DB.Entity.Enum.WorkflowEnum;

namespace DB.Entity.Assistance
{
    /// <summary>
    /// 审批流
    /// </summary>
    public abstract class WorkflowEntity
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 数据状态
        /// </summary>
        public bool IsStatus { get; set; } = true;
        /// <summary>
        /// 创建时间/只读
        /// </summary>
        public DateTime CreationTime { get; private set; } = DateTime.Now;
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreationUser { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 创建时间/只读
        /// </summary>
        public DateTime WorkflowCreationTime { get; private set; } = DateTime.Now;
        /// <summary>
        /// 审批人
        /// </summary>
        public string WorkflowApprover { get; set; }
        /// <summary>
        /// 审批时间
        /// </summary>
        public DateTime WorkflowTime { get; set; }
        /// <summary>
        /// 审批状态
        /// </summary>
        public WorkflowStatus? WorkflowStatus { get; set; }
    }
}
