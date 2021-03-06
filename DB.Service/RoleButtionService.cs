﻿using DB.Entity.Model;
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
using static DB.Entity.Enum.WorkflowEnum;

namespace DB.Service
{
    public class RoleButtionService : IRoleButtionService
    {
        private IRoleButtionRepository _roleButtionRepository { get; set; }
        private HttpContextUtil _httpContextUtil { get; set; }
        private RedisUtil _redisUtil { get; set; }
        public RoleButtionService(IRoleButtionRepository roleButtionRepository, HttpContextUtil httpContextUtil, RedisUtil redisUtil)
        {
            this._roleButtionRepository = roleButtionRepository;
            this._httpContextUtil = httpContextUtil;
            this._redisUtil = redisUtil;
        }

        /// <summary>
        /// 角色获取按钮关系
        /// </summary>
        /// <returns>BaseResult</returns>
        public async Task<BaseResult<List<RoleButtionEntity>>> QueryByRoleListID(Guid guid, List<ModuleButtionEntity> moduleButtionList)
        {
            //读取Redis角色信息
            var roleButtionlist = _redisUtil.GetTVlues<List<RoleButtionEntity>>(_redisUtil.RoleButtion(guid));
            if (roleButtionlist == null)
            {
                Expression<Func<RoleButtionEntity, bool>> where = LinqUtil.True<RoleButtionEntity>();
                where = where.AndAlso(e => e.RoleId == guid);
                IQueryable<RoleButtionEntity> list = await _roleButtionRepository.GetAllAsync(where);
                if (list != null)
                {
                    roleButtionlist = new List<RoleButtionEntity>();
                    //组装按钮集合
                    foreach (var item in list.ToList())
                    {
                        foreach (var modulebuttion in moduleButtionList)
                        {
                            if (item.ModuleButtionId == modulebuttion.Id)
                            {
                                item.ModuleButtion = modulebuttion;
                            }
                        }
                        roleButtionlist.Add(item);
                    }
                    //将用户按钮关系写入redis
                    _redisUtil.SetListValue(_redisUtil.RoleButtion(guid), roleButtionlist);
                    //redis空集合获取查询出来的结果

                }
            }

            return new BaseResult<List<RoleButtionEntity>>(roleButtionlist);
        }

        /// <summary>
        /// 通过session获取当前页面拥有那些按钮权限
        /// </summary>
        /// <returns></returns>
        public BaseResult<List<RoleButtionEntity>> QueryByRoleList(Guid guid)
        {
            //根据session获取用户对象
            //var userEntity = _httpContextUtil.GetSession<UserEntity>(KeyUtil.user_info);
            //读取Redis角色信息
            var roleButtionlist = _redisUtil.GetTVlues<List<RoleButtionEntity>>("RoleButtion-aa9c9ee8-3f5c-445a-ad51-fad03052ef28");

            var list = roleButtionlist.Where(a => a.ModuleButtion.ModuleId == guid).ToList();
            return new BaseResult<List<RoleButtionEntity>>(list);
        }
        /// <summary>
        /// 根据角色获取权限按钮
        /// </summary>
        /// <param name="RoleID">模块ID</param>
        /// <returns></returns>
        public async Task<BaseResult<List<RoleButtionEntity>>> QueryByRoleID(Guid roleID)
        {
            Expression<Func<RoleButtionEntity, bool>> where = LinqUtil.True<RoleButtionEntity>();
            where = where.AndAlso(e => e.RoleId == roleID);
            IQueryable<RoleButtionEntity> list = await _roleButtionRepository.GetAllAsync(where);
            return new BaseResult<List<RoleButtionEntity>>(list.ToList());
        }

        /// <summary>
        /// 根据角色删除按钮关系
        /// </summary>
        /// <param name="RoleID">模块ID</param>
        /// <returns></returns>
        public async Task<BaseResult<bool>> DelByRoleID(Guid guid)
        {
            Expression<Func<RoleButtionEntity, bool>> where = LinqUtil.True<RoleButtionEntity>();
            where = where.AndAlso(e => e.RoleId == guid);
            var total = await _roleButtionRepository.DeleteAsync(where);
            if (total)
            {
                return new BaseResult<bool>("删除成功！");
            }
            else
            {
                return new BaseResult<bool>("删除操作失败！");
            }
        }
        /// <summary>
        /// 建立按钮关系
        /// </summary>
        /// <param name="obj">按钮Id</param>
        /// <returns></returns>
        public async Task<BaseResult<bool>> AddRoleButtion(Guid guid, string obj)
        {
            List<RoleButtionEntity> roleModuleList = JsonNetHelper.DeserializeObject<List<RoleButtionEntity>>(obj);
            foreach (var item in roleModuleList)
            {

                item.WorkflowStatus = WorkflowStatus.ApprovalNotSubmitted;
                item.RoleId = guid;
            }
            if (await _roleButtionRepository.AddListAsync(roleModuleList))
            {
                return new BaseResult<bool>("模块保存成功！");
            }
            else
            {
                return new BaseResult<bool>("模块保存失败！", false);
            }
        }
        /// <summary>
        /// 根据当前登陆人查询当前模块按钮
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<BaseResult<bool>> QuertUserIdButtion(Guid guid)
        {

            return new BaseResult<bool>("查询按钮失败", false);
        }
    }
}
