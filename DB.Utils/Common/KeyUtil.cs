using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Utils.Common
{
    public static class KeyUtil
    {
        /// <summary>
        /// 存放当前登录用户账号用来给Redis组装Key
        /// </summary>
        public const string user_Number = "userNumber";
        /// <summary>
        /// 用户登录之后存放Session用户信息
        /// </summary>
        public const string user_info = "userinfo";
    }
}
