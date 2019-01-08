using System;
using System.Collections.Generic;
using System.Text;
using static DB.Entity.Enum.WorkflowEnum;

namespace DB.Entity
{
    /// <summary>
    /// 审批流
    /// </summary>
    public abstract class WorkflowEntity
    {
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
        public WorkflowStatus WorkflowStatus { get; set; }
    }
}
