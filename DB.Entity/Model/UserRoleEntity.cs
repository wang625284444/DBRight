using System;
using DB.Entity.Assistance;

namespace DB.Entity.Model
{
    /// <summary>
    /// 校色用户关联
    /// </summary>
    public sealed class UserRoleEntity : AssistanceEntity
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 用户外键
        /// </summary>
        public UserEntity User { get; set; }
        /// <summary>
        /// 角色外键
        /// </summary>
        public RoleEntity Role { get; set; }
    }
}
