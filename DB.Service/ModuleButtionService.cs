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
    public class ModuleButtionService : IModuleButtionService
    {
        IModuleButtionRepository _moduleButtionRepository { get; set; }
        public ModuleButtionService(IModuleButtionRepository moduleButtionRepository)
        {
            this._moduleButtionRepository = moduleButtionRepository;
        }
        /// <summary>
        /// 根据模块获取按钮
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public async Task<BaseResult<IQueryable<ModuleButtionEntity>>> QueryById(Guid moduleId)
        {
            Expression<Func<ModuleButtionEntity, bool>> where = LinqUtil.True<ModuleButtionEntity>();
            where = where.AndAlso(e => e.ModuleId == moduleId);
            IQueryable<ModuleButtionEntity> _moduleButtionEntity = await _moduleButtionRepository.GetAllAsync(where);
            return new BaseResult<IQueryable<ModuleButtionEntity>>(_moduleButtionEntity.AsQueryable());
        }
    }
}
