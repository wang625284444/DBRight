using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DB.Entity.Model;
using DB.Entity.Response;
using DB.IRepository.limit;
using DB.IService;
using DB.Utils.Extend;

namespace DB.Service
{
    public class RoleModuleService : IRoleModuleService
    {
        private IRoleModuleRepository _roleModuleRepository { get; set; }
        public RoleModuleService(IRoleModuleRepository roleModuleRepository)
        {
            this._roleModuleRepository = roleModuleRepository;

        }
        /// <summary>
        /// 查询角色信息
        /// </summary>
        /// <returns>BaseResult</returns>
        public async Task<BaseResult<IQueryable<RoleModuleEntity>>> GetQuery(Guid guid)
        {
            Expression<Func<RoleModuleEntity, bool>> where = LinqUtil.True<RoleModuleEntity>();
            where = where.AndAlso(e => e.RoleId == guid);
            IQueryable<RoleModuleEntity> _roleModulelist = await _roleModuleRepository.GetAllAsync(where);
            return new BaseResult<IQueryable<RoleModuleEntity>>(_roleModulelist.AsQueryable());
        }
    }
}
