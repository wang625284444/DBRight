using DB.Entity.Model;
using DB.Entity.Response;
using DB.IRepository.limit;
using DB.IService;
using DB.Utils.Extend;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DB.Service
{
    public class ModuleService : IModuleService
    {
        //注入用户管理操作
        private IModuleRepository _moduleRepository { get; set; }

        public ModuleService(IModuleRepository moduleRepository)
        {
            this._moduleRepository = moduleRepository;
        }
        /// <summary>
        /// 查询tree
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<BaseResult<ModuleEntity>> Query()
        {
            Expression<Func<ModuleEntity, bool>> where = LinqUtil.True<ModuleEntity>();
            where = where.AndAlso(e => 1 == 1);
            var _modulelist = await _moduleRepository.GetListAllAsync(where);
            return new BaseResult<ModuleEntity>("查询全部模块", _modulelist);
        }
        /// <summary>
        /// 根据角色信息查询模块
        /// </summary>
        /// <param name="guids">模块ID集合</param>
        /// <returns></returns>
        public async Task<BaseResult<ModuleEntity>> QueryInId(Guid[] moduleId)
        {
            Expression<Func<ModuleEntity, bool>> where = LinqUtil.True<ModuleEntity>();
            where = where.AndAlso(e => moduleId.Contains(e.Id));
            var _modulelist = await _moduleRepository.GetListAllAsync(where);
            return new BaseResult<ModuleEntity>("根据用户查询模块", _modulelist);
        }
    }
}
