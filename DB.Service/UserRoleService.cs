using DB.Entity.Model;
using DB.Entity.Response;
using DB.IRepository.limit;
using DB.IService;
using DB.Utils.Common;
using DB.Utils.Extend;
using DB.Utils.Redis;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DB.Service
{
    public class UserRoleService : IUserRoleService
    {
        private IUserRoleRepository _userRoleRepository { get; set; }

        private HttpContextUtil _httpContextUtil { get; set; }

        private RedisUtil _redisUtil { get; set; }
        
        public UserRoleService(IUserRoleRepository userRoleRepository, HttpContextUtil httpContextUtil, RedisUtil redisUtil)
        {
            this._userRoleRepository = userRoleRepository;
            this._httpContextUtil = httpContextUtil;
            this._redisUtil = redisUtil;
        }
        /// <summary>
        /// 根据用户获取角色信息
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<UserRoleEntity>> userRoleSessionById()
        {
            Expression<Func<UserRoleEntity, bool>> where = LinqUtil.True<UserRoleEntity>();

            var userEntity = _redisUtil.GetTVlues<UserEntity>(_redisUtil.user()); //_httpContextUtil.GetSessionJson<UserEntity>(KeyUtil.user_info);
            where = where.AndAlso(e => e.IsStatus == true && e.UserId == userEntity.Id);
            var userRolelist = await _userRoleRepository.GetAsync(where);
            if (userRolelist != null)
            {
                //写入Redis角色信息
                _redisUtil.SetTValue(_redisUtil.role(), userRolelist);
            }
            return new BaseResult<UserRoleEntity>(userRolelist);
        }
    }
}
