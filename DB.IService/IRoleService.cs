using DB.Entity.Model;
using DB.Entity.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.IService
{
    /// <summary>
    /// 角色服务接口
    /// </summary>
    public interface IRoleService
    {

        /// <summary>
        /// 查询角色信息
        /// </summary>
        /// <param name="roleEntity"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<Pager<IQueryable<RoleEntity>>> QueryRole(RoleEntity  roleEntity, int pageIndex, int pageSize);
        /// <summary>
        /// 查询已生效的角色信息
        /// </summary>
        /// <param name="roleEntity"></param>
        /// <returns></returns>
        Task<BaseResult<List<RoleEntity>>> QueryRoleEffective();
        /// <summary>
        /// 根据Session用户查询当前角色
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task<BaseResult<RoleEntity>> QueryById();
        /// <summary>
        /// 根据用户Id查询当前角色
        /// </summary>
        /// <returns></returns>
        Task<BaseResult<RoleEntity>> QueryById(Guid guid);

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="roleEntity"></param>
        /// <returns></returns>
        Task<BaseResult<RoleEntity>> AddRole(RoleEntity roleEntity);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<BaseResult<bool>> DelRoleId(Guid guid);
    }
}
