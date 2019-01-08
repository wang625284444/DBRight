using DB.Entity.Model;
using DB.Entity.Response;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DB.IService
{
    public interface IRoleModuleService
    {
        /// <summary>
        /// 根据用户ID查询角色
        /// </summary>
        /// <returns></returns>
        Task<BaseResult<IQueryable<RoleModuleEntity>>> GetQuery(Guid guid);
    }
}
