using DB.Entity.Assistance;
using System;

namespace DB.Entity.Model
{
    /// <summary>
    /// 角色
    /// </summary>
    public class RoleEntity : WorkflowEntity
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 父级Id
        /// </summary>
        public Guid Pid { get; set; }
    }
}
