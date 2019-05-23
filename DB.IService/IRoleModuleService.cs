using DB.Entity.Model;
using DB.Entity.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.IService
{
    public interface IRoleModuleService
    {
        [Obsolete("方法不再使用")]
        Task<BaseResult<IQueryable<RoleModuleEntity>>> QueryAll();
        /// <summary>
        /// 查询模块关联信息
        /// </summary>
        /// <param name="guid">角色ID</param>
        /// <returns></returns>
        Task<BaseResult<IQueryable<RoleModuleEntity>>> QueryByRoleId(Guid guid);

        /// <summary>
        /// 添加角色权限
        /// </summary>
        /// <param name="roleModuleList"></param>
        /// <returns></returns>
        Task<BaseResult<bool>> AddModuleList(string obj);

        /// <summary>
        /// 根据角色删除全部权限关系
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task<BaseResult<bool>> DelModuleList(Guid guid);
    }
}
