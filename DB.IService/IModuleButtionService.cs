using DB.Entity.Model;
using DB.Entity.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.IService
{
    public interface IModuleButtionService
    {
        /// <summary>
        /// 根据模块获取按钮
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        Task<BaseResult<IQueryable<ModuleButtionEntity>>> QueryById(Guid moduleId);
    }
}
