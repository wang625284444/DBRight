using DB.Entity.Assistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entity.Model
{
    /// <summary>
    /// 角色关联模块
    /// </summary>
    public class RoleModuleEntity : AssistanceEntity
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        ///  角色Id
        /// </summary>
        public Guid RoleId { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public RoleEntity Role { get; set; }
        /// <summary>
        /// 模块Id
        /// </summary>
        public Guid ModuleId { get; set; }
        /// <summary>
        /// 模块
        /// </summary>
        public ModuleEntity Module { get; set; }
        
    }
}
