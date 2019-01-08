using DB.Entity.Model;
using DB.Entity.Response;
using System;
using System.Collections.Generic;
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
        /// <returns></returns>
        Task<BaseResult<RoleEntity>> Query();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task<BaseResult<RoleEntity>> QueryById();

    }
}
