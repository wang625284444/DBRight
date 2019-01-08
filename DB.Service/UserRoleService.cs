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
        private IUserRoleService _userRoleService { get; set; }

        private IUserRoleRepository _userRoleRepository { get; set; }

        private HttpContextUtil httpContextUtil { get; set; }
        public UserRoleService(IUserRoleService userRoleService)
        {
            this._userRoleService = userRoleService;
        }
        /// <summary>
        /// 根据用户获取校色信息
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<UserRoleEntity>> userRoleSessionById()
        {
            Expression<Func<UserRoleEntity, bool>> where = LinqUtil.True<UserRoleEntity>();
            var userEntity = httpContextUtil.GetObjectAsJson<UserEntity>(KeyUtil.user_info);
            where = where.AndAlso(e => e.IsStatus == false && e.User.Id == userEntity.Id);
            var _userRolelist = await _userRoleRepository.GetAsync(where);
            return new BaseResult<UserRoleEntity>(_userRolelist);
        }
    }
}
