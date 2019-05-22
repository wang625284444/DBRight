using DB.Entity.Model;
using DB.Entity.Response;
using DB.IRepository.limit;
using DB.IService;
using DB.Utils.Common;
using DB.Utils.Extend;
using DB.Utils.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DB.Service
{
    public class ModuleService : IModuleService
    {
        private IModuleRepository _moduleRepository { get; set; }
        private HttpContextUtil _httpContextUtil { get; set; }
        private RedisUtil _redisUtil { get; set; }
        public ModuleService(IModuleRepository moduleRepository, HttpContextUtil httpContextUtil, RedisUtil redisUtil)
        {
            this._moduleRepository = moduleRepository;
            this._httpContextUtil = httpContextUtil;
            this._redisUtil = redisUtil;
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
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public async Task<BaseResult<ModuleEntity>> QueryInId(Guid[] moduleId, Guid guid)
        {
            var modulelist = _redisUtil.GetListValue<ModuleEntity>(_redisUtil.Module(guid));
            if (modulelist == null)
            {
                Expression<Func<ModuleEntity, bool>> where = LinqUtil.True<ModuleEntity>();
                where = where.AndAlso(e => moduleId.Contains(e.Id));
                modulelist = await _moduleRepository.GetListAllAsync(where);
                if (modulelist != null)
                {
                    _redisUtil.SetListValue(_redisUtil.Module(guid), modulelist);
                }
            }
            return new BaseResult<ModuleEntity>("根据用户查询模块", modulelist);
        }
    }
}
