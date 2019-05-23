using DB.Entity.Model;
using DB.Entity.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DB.IService
{
    public interface IRoleButtionService
    {
        /// <summary>
        /// 根据角色获取按钮关系
        /// </summary>
        /// <returns>BaseResult</returns>
        Task<BaseResult<List<RoleButtionEntity>>> QueryByRoleListID(Guid guid,List<ModuleButtionEntity> moduleButtionList);

        /// <summary>
        /// 通过session获取当前页面拥有那些按钮权限
        /// </summary>
        /// <returns></returns>
        BaseResult<List<RoleButtionEntity>> QueryByRoleList(Guid guid);
        /// <summary>
        /// 根据角色获取权限按钮
        /// </summary>
        /// <param name="RoleID">模块ID</param>
        /// <returns></returns>
        Task<BaseResult<List<RoleButtionEntity>>> QueryByRoleID(Guid RoleID);
        /// <summary>
        /// 根据角色删除按钮关系
        /// </summary>
        /// <param name="RoleID">模块ID</param>
        /// <returns></returns>
        Task<BaseResult<bool>> DelByRoleID(Guid guid);
        /// <summary>
        /// 建立按钮关系
        /// </summary>
        /// <param name="obj">按钮Id</param>
        /// <returns></returns>
        Task<BaseResult<bool>> AddRoleButtion(Guid guid, string obj);

        Task<BaseResult<bool>> QuertUserIdButtion(Guid guid);
    }
}
