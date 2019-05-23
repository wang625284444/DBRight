using DB.Entity.Model;
using DB.Entity.Response;
using System;
using System.Threading.Tasks;

namespace DB.IService
{
    public interface IUserRoleService
    {
        /// <summary>
        /// 根据用户获取角色关系
        /// </summary>
        /// <returns></returns>
        Task<BaseResult<UserRoleEntity>> userRoleSessionById();
    }
}
