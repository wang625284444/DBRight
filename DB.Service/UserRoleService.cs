using DB.Entity.Model;
using DB.Entity.Response;
using DB.IRepository.limit;
using DB.IService;
using DB.Utils.Common;
using DB.Utils.Extend;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DB.Service
{
    public class UserRoleService : IUserRoleService
    {
        private IUserRoleRepository _userRoleRepository { get; set; }

        private HttpContextUtil _httpContextUtil { get; set; }
        public UserRoleService(IUserRoleRepository userRoleRepository, HttpContextUtil httpContextUtil)
        {
            this._userRoleRepository = userRoleRepository;
            this._httpContextUtil = httpContextUtil;
        }
        /// <summary>
        /// 根据用户获取校色信息
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<UserRoleEntity>> userRoleSessionById()
        {
            Expression<Func<UserRoleEntity, bool>> where = LinqUtil.True<UserRoleEntity>();
            var userEntity = _httpContextUtil.GetObjectAsJson<UserEntity>(KeyUtil.user_info);
            where = where.AndAlso(e => e.IsStatus == true && e.UserId == userEntity.Id);
            var _userRolelist = await _userRoleRepository.GetAsync(where);
            if (_userRolelist != null)
            {
                _httpContextUtil.setObjectAsJson(KeyUtil.role_info, _userRolelist);
            }
            return new BaseResult<UserRoleEntity>(_userRolelist);
        }
    }
}
