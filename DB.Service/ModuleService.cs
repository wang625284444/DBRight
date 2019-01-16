using DB.Entity.Model;
using DB.Entity.Response;
using DB.IRepository.limit;
using DB.IService;
using DB.Utils.Common;
using DB.Utils.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DB.Service
{
    public class ModuleService : IModuleService
    {
        //注入用户管理操作
        private IModuleRepository _moduleRepository { get; set; }

        private HttpContextUtil _httpContextUtil { get; set; }
        public ModuleService(IModuleRepository moduleRepository, HttpContextUtil httpContextUtil)
        {
            this._moduleRepository = moduleRepository;
            this._httpContextUtil = httpContextUtil;
        }
        /// <summary>
        /// 查询tree
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<List<ModuleEntity>>> Query()
        {
            Expression<Func<ModuleEntity, bool>> where = LinqUtil.True<ModuleEntity>();
            IQueryable<ModuleEntity> list = await _moduleRepository.GetAllAsync(where);
            return new BaseResult<List<ModuleEntity>>(list.ToList());
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
            if (_modulelist != null)
            {
                _httpContextUtil.setObjectAsJson(KeyUtil.module_info, _modulelist);
            }
            return new BaseResult<ModuleEntity>("根据用户查询模块", _modulelist);
        }
    }
}
