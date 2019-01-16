using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Utils.Common
{
    public static class KeyUtil
    {
        /// <summary>
        /// 用户登录之后存放Session用户信息
        /// </summary>
        public const string user_info = "userinfo";
        /// <summary>
        /// 用户登录之后存放Session角色信息
        /// </summary>
        public const string role_info = "roleinfo";
        /// <summary>
        /// 用户登录之后存放Session模块信息
        /// </summary>
        public const string module_info = "moduleinfo";
    }
}
