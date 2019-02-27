using System;
using DB.Entity.Assistance;

namespace DB.Entity.Model
{
    /// <summary>
    /// 校色用户关联
    /// </summary>
    public sealed class UserRoleEntity : WorkflowEntity
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 用户外键ID
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 用户外键
        /// </summary>
        public UserEntity User { get; set; }
        /// <summary>
        /// 角色外键ID
        /// </summary>
        public Guid RoleId { get; set; }
        /// <summary>
        /// 角色外键
        /// </summary>
        public RoleEntity Role { get; set; }
    }
}
