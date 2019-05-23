using DB.Entity.Model;
using DB.Entity.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DB.Entity.Enum.UserEnum;

namespace DB.IService
{
    public interface IUserService
    {

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="UserAccount">账号</param>
        /// <param name="UserPassword">密码</param>
        /// <returns>登录状态</returns>
        Task<BaseResult<UserEntity>> Login(string UserAccount, string UserPassword);

        /// <summary>
        /// 更新用户状态
        /// </summary>
        /// <param name="userEntity">UserEntity</param>
        /// <param name="statusEnum">用户状态</param>
        /// <returns></returns>
        Task<BaseResult<UserEntity>> ModifyStatus(UserEntity userEntity, StatusEnum statusEnum);

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="userEntity">UserEntity</param>
        /// <returns></returns>
        Task<Pager<IQueryable<UserEntity>>> QueryUser(UserEntity userEntity, int pageIndex, int pageSize);
        /// <summary>
        /// 获取新的用户编码
        /// </summary>
        /// <returns></returns>
        Task<Pager<string>> QueryUserNumber();
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userEntity">UserEntity</param>
        /// <returns></returns>
        Task<BaseResult<bool>> AddUser(UserEntity userEntity);

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userEntity">UserEntity</param>
        /// <returns></returns>
        Task<BaseResult<bool>> ModifyUser(UserEntity userEntity);
        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<BaseResult<bool>> DelUserId(Guid obj);
        /// <summary>
        /// 更改用户状态
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task<BaseResult<bool>> UpdateStatusUserId(Guid guid);
    }
}
