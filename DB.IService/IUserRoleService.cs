using DB.Entity.Model;
using DB.Entity.Response;
using System;
using System.Threading.Tasks;

namespace DB.IService
{
    public interface IUserRoleService
    {
        /// <summary>
        /// 根据登陆用户查询角色
        /// </summary>
        /// <param name="guid">用户ID</param>
        /// <returns></returns>
        Task<BaseResult<UserRoleEntity>> userRoleSessionById();
    }
}
