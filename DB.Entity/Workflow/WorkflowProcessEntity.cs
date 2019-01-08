using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entity.Workflow
{
    /// <summary>
    /// 工作流流程配置
    /// </summary>
    public class WorkflowProcessEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 顺序
        /// </summary>
        public long Sequence { get; set; }
        /// <summary>
        /// 顺序名称
        /// </summary>
        public string SequenceName { get; set; }
        /// <summary>
        /// 外键ID
        /// </summary>
        public Guid WorkflowConfigureId { get; set; }
        /// <summary>
        /// 创建关系
        /// </summary>
        public WorkflowConfigureEntity WorkflowConfigureEntity { get; set; }
        /// <summary>
        /// 数据状态
        /// </summary>
        public bool IsStatus { get; set; }
        /// <summary>
        /// 创建时间/只读
        /// </summary>
        public DateTime CreationTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreationUser { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
