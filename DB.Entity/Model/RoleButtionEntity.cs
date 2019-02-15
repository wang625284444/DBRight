using DB.Entity.Assistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entity.Model
{
    public class RoleButtionEntity : AssistanceEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 角色外键ID
        /// </summary>
        public Guid RoleId { get; set; }
        /// <summary>
        /// 创建角色外键
        /// </summary>
        public RoleEntity Role { get; set; }
        /// <summary>
        /// 模块按钮ID
        /// </summary>
        public Guid ModuleButtionId { get; set; }
        /// <summary>
        /// 创建按钮外键
        /// </summary>
        public ModuleButtionEntity ModuleButtion { get; set; }



    }
}
