using DB.Entity.Assistance;
using System;

namespace DB.Entity.Model
{
    /// <summary>
    /// 模块
    /// </summary>
    public class ModuleEntity: AssistanceEntity
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string UrlName { get; set; }
        /// <summary>
        /// 权限路径
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 子关系
        /// </summary>
        public Guid Pid { get; set; }

    }
}
