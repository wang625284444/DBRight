using DB.Entity.Assistance;
using static DB.Entity.Enum.UserEnum;

namespace DB.Entity.Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public sealed class UserEntity : WorkflowEntity
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        public string UserNumber { get; set; }
        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserAccount { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPassword { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 电话号
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Mail { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        public StatusEnum Status { get; set; }

    }
}
