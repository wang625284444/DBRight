using DB.Entity.Model;
using DB.Entity.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB.IService
{
    public interface IModuleService
    {
        /// <summary>
        /// 查询全部模块
        /// </summary>
        /// <returns></returns>
        Task<BaseResult<List<ModuleEntity>>> Query();
        /// <summary>
        /// 根据角色信息查询模块
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task<BaseResult<ModuleEntity>> QueryInId(Guid[] moduleId,Guid guid);
    }
}
