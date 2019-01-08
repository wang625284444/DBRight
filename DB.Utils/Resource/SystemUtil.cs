namespace DB.Utils.Resource
{
    /// <summary>
    /// 封装Messages_CN资源文件,使其改动就能够处理语言信息
    /// </summary>
    /// 修改记录：
    public static class SystemUtil
    {
        /// <summary>
        /// 根据statuscode返回查询到的汉字信息并且提交给前台
        /// </summary>
        /// <param name="statuscode">标识符</param>
        /// <returns></returns>
        public static string getMessage(int statuscode)
        {
            string result = Messages_CN.OK;
            switch (statuscode)
            {
                //系统错误(1000以内)
                case 200:
                    result = Messages_CN.OK;
                    break;
                case 201:
                    result = Messages_CN.Error;
                    break;
                case 202:
                    result = Messages_CN.Empty;
                    break;
                case 400:
                    result = Messages_CN.NoAddress;
                    break;
                case 500:
                    result = Messages_CN.ServerData;
                    break;
                case 301:
                    result = Messages_CN.NoLogin;
                    break;
                case 800:
                    result = Messages_CN.ParaError;
                    break;
                case 801:
                    result = Messages_CN.PortError;
                    break;
                case 802:
                    result = Messages_CN.ReadError;
                    break;
                case 803:
                    result = Messages_CN.NoError;
                    break;
                case 808:
                    result = Messages_CN.ParaEmpty;
                    break;
                case 900:
                    result = Messages_CN.AlreadyExists;
                    break;
                case 901:
                    result = Messages_CN.ExistsRelation;
                    break;

                //用户管理(1000-2000以内)
                case 1000:
                    result = Messages_CN.UserAccountDoNotExist;
                    break;
                case 1001:
                    result = Messages_CN.UserPasswordError1;
                    break;
                case 1002:
                    result = Messages_CN.UserPasswordError2;
                    break;
                case 1003:
                    result = Messages_CN.UserPasswordError3;
                    break;
                case 1004:
                    result = Messages_CN.UserPasswordError;
                    break;
                case 1005:
                    result = Messages_CN.UserPasswordDisable;
                    break;
                case 1020:
                    result = Messages_CN.UserAlreadyExists;
                    break;
                default:
                    result = Messages_CN.NoError;
                    break;

            }
            return result;
        }
    }
}
