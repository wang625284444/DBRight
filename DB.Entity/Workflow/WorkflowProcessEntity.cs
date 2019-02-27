using DB.Entity.Assistance;
using System;

namespace DB.Entity.Workflow
{
    /// <summary>
    /// 工作流流程配置
    /// </summary>
    public class WorkflowProcessEntity: AssistanceEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 审核顺序
        /// </summary>
        public long Sequence { get; set; }
        /// <summary>
        /// 审核顺序名称
        /// </summary>
        public string SequenceName { get; set; }
        /// <summary>
        /// 外键ID
        /// </summary>
        public Guid WorkflowConfigureId { get; set; }
    }
}
