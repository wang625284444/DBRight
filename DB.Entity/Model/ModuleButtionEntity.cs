using System;

namespace DB.Entity.Model
{
    /// <summary>
    /// 权限按钮实体
    /// </summary>
    public class ModuleButtionEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 按钮名称
        /// </summary>
        public string ButtionName { get; set; }

        public string ButtionId { get; set; }
        /// <summary>
        /// 模块ID
        /// </summary>
        public Guid ModuleId { get; set; }
        /// <summary>
        /// 关联模块实体
        /// </summary>
        public ModuleEntity Module { get; set; }

    }
}
