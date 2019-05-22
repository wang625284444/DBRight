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
        /// 根据用户获取角色关系
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<UserRoleEntity>> userRoleSessionById()
        {
            //根据session获取用户对象
            var userEntity = _httpContextUtil.GetSession<UserEntity>(KeyUtil.user_info);
            //根据用户ID查找redis是否有当前角色
            var userRolelist = _redisUtil.GetTVlues<UserRoleEntity>(_redisUtil.UserRole(userEntity.Id));
            //判断角色redis是否存在
            if (userRolelist == null)
            {
                Expression<Func<UserRoleEntity, bool>> where = LinqUtil.True<UserRoleEntity>();
                //根据用户信息查找数据库中的角色
                where = where.AndAlso(e => e.IsStatus == true && e.UserId == userEntity.Id);
                userRolelist = await _userRoleRepository.GetAsync(where);
                if (userRolelist != null)
                {
                    //写入Redis角色信息
                    _redisUtil.SetTValue(_redisUtil.UserRole(userEntity.Id), userRolelist);
                }
            }
            return new BaseResult<UserRoleEntity>(userRolelist);
        }
    }
}
