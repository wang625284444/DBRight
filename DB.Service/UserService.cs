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
using static DB.Entity.Enum.UserEnum;
using static DB.Entity.Enum.WorkflowEnum;

namespace DB.Service
{
    public class UsersService : IUserService
    {
        //注入用户管理操作
        private IUserRepository _userRepository { get; set; }
        //注入HttpContext对象
        private HttpContextUtil _httpContextUtil { get; set; }

        public UsersService(IUserRepository userRepository, HttpContextUtil httpContextUtil)
        {
            this._userRepository = userRepository;
            this._httpContextUtil = httpContextUtil;
        }

        /// <summary>
        /// 登录操作
        /// </summary>
        /// <param name="userAccount"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public async Task<BaseResult<UserEntity>> Login(string userAccount, string userPassword)
        {
            if (string.IsNullOrEmpty(userAccount) || string.IsNullOrEmpty(userPassword))
            {
                return new BaseResult<UserEntity>("参数不能为空");
            }
            Expression<Func<UserEntity, bool>> where = LinqUtil.True<UserEntity>();
            //根据账号获取用户信息
            where = where.AndAlso(e => e.UserAccount == userAccount && e.IsStatus == false);
            var usersEntity = await _userRepository.GetAsync(where);
            if (usersEntity != null)
            {
                //用户审核状态判断
                switch (usersEntity.WorkflowStatus)
                {
                    case WorkflowStatus.ApprovalRejection:
                        return new BaseResult<UserEntity>("审批拒绝用户，请联系管理员！");
                    case WorkflowStatus.ApprovalToBeAudited:
                        return new BaseResult<UserEntity>("待审核用户，请联系管理员！");
                }
                //检查当前数据状态
                switch (usersEntity.Status)
                {
                    case StatusEnum.Normal:
                        if (usersEntity.UserPassword != userPassword)
                        {
                            //更新用户状态错误一次
                            return await ModifyStatus(usersEntity, StatusEnum.Remind1);
                        }
                        else
                        {
                            _httpContextUtil.setObjectAsJson(KeyUtil.user_info, usersEntity);
                            return new BaseResult<UserEntity>(usersEntity);
                        }
                    case StatusEnum.Remind1:
                        if (usersEntity.UserPassword != userPassword)
                        {
                            //更新用户状态错误两次
                            return await ModifyStatus(usersEntity, StatusEnum.Remind2);
                        }
                        else
                        {
                            //将账号回复正常
                            return await ModifyStatus(usersEntity, StatusEnum.Normal);
                        }
                    case StatusEnum.Remind2:
                        if (usersEntity.UserPassword != userPassword)
                        {
                            //更新用户状态错误三次
                            return await ModifyStatus(usersEntity, StatusEnum.Remind3);
                        }
                        else
                        {
                            //将账号回复正常
                            return await ModifyStatus(usersEntity, StatusEnum.Normal);
                        }
                    case StatusEnum.Remind3:
                        if (usersEntity.UserPassword != userPassword)
                        {
                            //将账号锁定
                            return await ModifyStatus(usersEntity, StatusEnum.Locking);
                        }
                        else
                        {
                            //将账号回复正常
                            return await ModifyStatus(usersEntity, StatusEnum.Normal);
                        }
                    case StatusEnum.Disable:
                        //提醒用户账号停用或锁定
                        return new BaseResult<UserEntity>("用户账号停用或锁定");
                    case StatusEnum.Locking:
                        //提醒用户账号停用或锁定
                        return new BaseResult<UserEntity>("用户账号停用或锁定");
                }
            }
            //用户不存在
            return new BaseResult<UserEntity>("用户不存在");
        }

        /// <summary>
        /// 更新用户状态
        /// </summary>
        /// <param name="userEntity">UsersEntity信息</param>
        /// <param name="statusEnum">更新状态</param>
        /// <returns></returns>
        public async Task<BaseResult<UserEntity>> ModifyStatus(UserEntity userEntity, StatusEnum statusEnum)
        {
            BaseResult<UserEntity> result = new BaseResult<UserEntity>();
            if (userEntity != null)
            {
                userEntity.Status = statusEnum;
                var istype = await _userRepository.UpdateAsync(userEntity);
                if (istype)
                {
                    switch (statusEnum)
                    {
                        case StatusEnum.Normal:
                            //正常数据写入session
                            //httpContextUtil.setObjectAsJson(KeyUtil.user_info, userEntity);
                            return new BaseResult<UserEntity>(userEntity);
                        case StatusEnum.Remind1:
                            //锁定一次
                            return new BaseResult<UserEntity>("用户错误2次，错误3次锁定账号！");
                        case StatusEnum.Remind2:
                            //锁定两次
                            return new BaseResult<UserEntity>("用户错误2次，错误2次锁定账号！");
                        case StatusEnum.Remind3:
                            //锁定三次
                            return new BaseResult<UserEntity>("用户错误3次，错误1次锁定账号！");
                        case StatusEnum.Locking:
                            //锁定账号
                            return new BaseResult<UserEntity>("用户错误3次，账号锁定！");
                        case StatusEnum.Disable:
                            //锁定禁用
                            return new BaseResult<UserEntity>("当前用户已禁用！");
                    }
                    //操作成功
                    return new BaseResult<UserEntity>("登陆成功！");
                }
                else
                {
                    //操作失败
                    return new BaseResult<UserEntity>("操作失败！");
                }
            }
            else
            {
                //数据为空
                return new BaseResult<UserEntity>("用户不存在！");
            }
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        public async Task<Pager<IQueryable<UserEntity>>> QueryUser(UserEntity userEntity, int pageIndex, int pageSize)
        {
            List<UserEntity> UserList = new List<UserEntity>();
            Expression<Func<UserEntity, bool>> where = LinqUtil.True<UserEntity>();
            if (userEntity.UserNumber != null)
            {
                where = where.AndAlso(e => e.UserNumber == userEntity.UserNumber);
            }
            if (userEntity.UserName != null)
            {
                where = where.AndAlso(e => e.UserName == userEntity.UserName);
            }
            if (userEntity.UserAccount != null)
            {
                where = where.AndAlso(e => e.UserAccount == userEntity.UserAccount);
            }
            if (userEntity.WorkflowStatus != null)
            {
                where = where.AndAlso(e => e.WorkflowStatus == userEntity.WorkflowStatus);
            }

            var total = await _userRepository.CountAsync(where);
            IQueryable<UserEntity> list = await _userRepository.GetPageAllAsync<UserEntity, DateTime, UserEntity>(pageIndex, pageSize, where, c => c.CreationTime, null);
            return new Pager<IQueryable<UserEntity>>(total, list.AsQueryable());
        }

        /// <summary>
        /// 获取新的用户编码
        /// </summary>
        /// <returns>用户编码</returns>
        public async Task<Pager<string>> QueryUserNumber()
        {
            Expression<Func<UserEntity, bool>> where = LinqUtil.True<UserEntity>();
            var total = await _userRepository.GetAsync(where);
            return new Pager<string>(100, "");
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userEntity">UsersEntity</param>
        /// <returns></returns>
        public async Task<BaseResult<bool>> AddUser(UserEntity userEntity)
        {
            Expression<Func<UserEntity, bool>> where = LinqUtil.True<UserEntity>();
            where = where.AndAlso(e => e.UserAccount == userEntity.UserAccount);
            if (!await _userRepository.IsExistAsync(where))
            {
                userEntity.WorkflowStatus = WorkflowStatus.ApprovalNotSubmitted;
                if (await _userRepository.AddAsync(userEntity))
                {
                    return new BaseResult<bool>("用户添加成功！");
                }
                else
                {
                    return new BaseResult<bool>("用户添加失败！", false);
                }
            }
            else
            {
                return new BaseResult<bool>("用户已存在，请重新注册!", false);
            }
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userEntity">UsersEntity</param>
        /// <returns></returns>
        public async Task<BaseResult<bool>> ModifyUser(UserEntity userEntity)
        {
            //判断当前数据是否在审核状态，审核中不可修改
            if (userEntity.WorkflowStatus != WorkflowStatus.ApprovalToBeAudited)
            {
                return new BaseResult<bool>("当前数据审核中不可修改！");
            }
            Expression<Func<UserEntity, bool>> where = LinqUtil.True<UserEntity>();
            where = where.AndAlso(e => e.Id == userEntity.Id);
            var _userentity = await _userRepository.GetAsync(where);
            _userentity.UpdateTime = DateTime.Now;
            _userentity.UserName = userEntity.UserName;
            _userentity.UserPassword = userEntity.UserPassword;
            _userentity.PhoneNumber = userEntity.PhoneNumber;
            _userentity.Mail = userEntity.Mail;
            //判断返回内容
            if (await _userRepository.UpdateAsync(_userentity))
            {
                return new BaseResult<bool>("用户更新成功！");
            }
            else
            {
                return new BaseResult<bool>("用户更新失败！");
            }
        }

        /// <summary>
        /// 用户删除
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<BaseResult<bool>> DelUserId(string obj)
        {
            List<UserEntity> userListEntity = JsonNetHelper.DeserializeObject<List<UserEntity>>(obj);
            var ser = userListEntity.Where(e => e.Id == _httpContextUtil.GetObjectAsJson<UserEntity>(KeyUtil.user_info).Id);
            if (ser.Count() == 0)
            {
                var total = await _userRepository.DeleteListAsync(userListEntity);
                if (total)
                {
                    return new BaseResult<bool>("删除用户成功！");
                }
                else
                {
                    return new BaseResult<bool>("删除用户操作失败！");
                }
            }
            return new BaseResult<bool>("不可删除自己！");
        }

        /// <summary>
        /// 更改用户状态
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<BaseResult<bool>> UpdateStatusUserId(Guid guid)
        {
            if (_httpContextUtil.GetObjectAsJson<UserEntity>(KeyUtil.user_info).Id != guid)
            {
                string statusName = string.Empty;
                Expression<Func<UserEntity, bool>> where = LinqUtil.True<UserEntity>();
                where = where.AndAlso(e => e.Id == guid);
                var _userentity = await _userRepository.GetAsync(where);
                if (_userentity != null)
                {
                    //禁用锁定账号均可设置正常用户
                    if (_userentity.Status == StatusEnum.Disable || _userentity.Status == StatusEnum.Locking)
                    {
                        //正常用户
                        _userentity.Status = StatusEnum.Normal;
                        statusName = "启用";
                    }
                    else
                    {
                        //禁用用户
                        _userentity.Status = StatusEnum.Disable;
                        statusName = "禁用";
                    }
                    var total = await _userRepository.UpdateAsync(_userentity);
                    if (total)
                    {
                        return new BaseResult<bool>("更新用户状态成功已" + statusName + "！");
                    }
                    else
                    {
                        return new BaseResult<bool>("更新用户状态失败！");
                    }
                }
            }
            return new BaseResult<bool>("不可禁用自己！");

        }
    }
}
