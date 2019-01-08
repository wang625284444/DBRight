using System;

namespace DB.Entity.Workflow
{
    /// <summary>
    /// 工作流配置
    /// </summary>
    public class WorkflowConfigureEntity
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 配置信息
        /// </summary>
        public string ConfigureName { get; set; }
        /// <summary>
        /// 数据状态
        /// </summary>
        public bool IsStatus { get; set; }
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

    }
}
