using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entity.Enum
{
    public sealed class UserEnum
    {
        /// <summary>
        /// 用户状态
        /// </summary>
        public enum StatusEnum
        {
            /// <summary>
            /// 正常
            /// </summary>
            Normal = 0,
            /// <summary>
            /// 错误一次
            /// </summary>
            Remind1 = 1,
            /// <summary>
            /// 错误两次
            /// </summary>
            Remind2 = 2,
            /// <summary>
            /// 错误三次
            /// </summary>
            Remind3 = 3,
            /// <summary>
            /// 错误四次，锁定账号
            /// </summary>
            Locking = 4,
            /// <summary>
            /// 禁用/停用账号
            /// </summary>
            Disable = 5

        }
    }
}
