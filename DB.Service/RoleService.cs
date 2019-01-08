using DB.Entity.Model;
using DB.Entity.Response;
using System;
using DB.IRepository.limit;
using DB.IService;
using DB.Utils.Extend;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DB.Utils.Common;

namespace DB.Service
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository { get; set; }
        private HttpContextUtil _httpContextUtil { get; set; }
        public RoleService(IRoleRepository roleRepository, HttpContextUtil httpContextUtil)
        {
            this._roleRepository = roleRepository;
            this._httpContextUtil = httpContextUtil;
        }
        /// <summary>
        /// 查询角色信息
        /// </summary>
        /// <returns>BaseResult</returns>
        public async Task<BaseResult<RoleEntity>> Query()
        {
            Expression<Func<RoleEntity, bool>> where = LinqUtil.True<RoleEntity>();
            where = where.AndAlso(e => e.IsStatus == false);
            var list = await _roleRepository.GetAsync(where);
            return new BaseResult<RoleEntity>(list);
        }
        /// <summary>
        /// 根据ID查询当前角色
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<BaseResult<RoleEntity>> QueryById()
        {
            var usersEntity = _httpContextUtil.GetObjectAsJson<UserEntity>(KeyUtil.user_info);
            Expression<Func<RoleEntity, bool>> where = LinqUtil.True<RoleEntity>();
            where = where.AndAlso(e => e.IsStatus == false || e.Id == usersEntity.Id);
            var _rolelist = await _roleRepository.GetAsync(where);
            return new BaseResult<RoleEntity>(_rolelist);
        }
    }
}
