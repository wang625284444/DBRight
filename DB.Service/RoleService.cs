﻿using DB.Entity.Model;
using DB.Entity.Response;
using System;
using DB.IRepository.limit;
using DB.IService;
using DB.Utils.Extend;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DB.Utils.Common;
using System.Linq;
using System.Collections.Generic;
using static DB.Entity.Enum.WorkflowEnum;
using DB.Utils.Redis;

namespace DB.Service
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository { get; set; }
        private HttpContextUtil _httpContextUtil { get; set; }
        private RedisUtil _redisUtil { get; set; }
        public RoleService(IRoleRepository roleRepository, HttpContextUtil httpContextUtil, RedisUtil redisUtil)
        {
            this._roleRepository = roleRepository;
            this._httpContextUtil = httpContextUtil;
            this._redisUtil = redisUtil;
        }

        /// <summary>
        /// 查询角色信息
        /// </summary>
        /// <returns>BaseResult</returns>
        public async Task<Pager<IQueryable<RoleEntity>>> QueryRole(RoleEntity roleEntity, int pageIndex, int pageSize)
        {
            Expression<Func<RoleEntity, bool>> where = LinqUtil.True<RoleEntity>();
            if (roleEntity.RoleName != null)
            {
                where = where.AndAlso(e => e.RoleName == roleEntity.RoleName);
            }
            var total = await _roleRepository.CountAsync(where);
            IQueryable<RoleEntity> list = await _roleRepository.GetPageAllAsync<RoleEntity, DateTime, RoleEntity>(pageIndex, pageSize, where, c => c.CreationTime, null);
            return new Pager<IQueryable<RoleEntity>>(total, list.AsQueryable());
        }

        /// <summary>
        /// 查询已生效的角色信息
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public async Task<BaseResult<List<RoleEntity>>> QueryRoleEffective()
        {
            Expression<Func<RoleEntity, bool>> where = LinqUtil.True<RoleEntity>();
            where = where.AndAlso(e => e.WorkflowStatus == WorkflowStatus.ApprovalAndApproval);
            IQueryable<RoleEntity> list = await _roleRepository.GetAllAsync(where);
            return new BaseResult<List<RoleEntity>>(list.ToList());
        }

        /// <summary>
        /// 根据Session用户查询当前角色
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<RoleEntity>> QueryById()
        {
            var usersEntity = _httpContextUtil.GetSession<UserEntity>(KeyUtil.user_info);
            Expression<Func<RoleEntity, bool>> where = LinqUtil.True<RoleEntity>();
            where = where.AndAlso(e => e.IsStatus == true || e.Id == usersEntity.Id);
            var _rolelist = await _roleRepository.GetAsync(where);
            return new BaseResult<RoleEntity>(_rolelist);
        }

        /// <summary>
        /// 根据用户Id查询当前角色
        /// </summary>
        /// <param name="guid">角色ID</param>
        /// <returns></returns>
        public async Task<BaseResult<RoleEntity>> QueryById(Guid guid)
        {
            //redis获取角色信息
            var rolelist = _redisUtil.GetTVlues<RoleEntity>(_redisUtil.Role(guid));
            //判断角色在redis是否存在
            if (rolelist == null)
            {
                Expression<Func<RoleEntity, bool>> where = LinqUtil.True<RoleEntity>();
                where = where.AndAlso(e => e.IsStatus == false || e.Id == guid);
                rolelist = await _roleRepository.GetAsync(where);
                if (rolelist != null)
                {
                    //写入redis
                    _redisUtil.SetTValue(_redisUtil.Role(guid), rolelist);
                }
            }

            return new BaseResult<RoleEntity>(rolelist);
        }

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="roleEntity"></param>
        /// <returns></returns>
        public async Task<BaseResult<RoleEntity>> AddRole(RoleEntity roleEntity)
        {
            Expression<Func<RoleEntity, bool>> where = LinqUtil.True<RoleEntity>();
            where = where.AndAlso(e => e.RoleName == roleEntity.RoleName);
            if (!await _roleRepository.IsExistAsync(where))
            {
                roleEntity.WorkflowStatus = WorkflowStatus.ApprovalNotSubmitted;
                if (await _roleRepository.AddAsync(roleEntity))
                {
                    return new BaseResult<RoleEntity>("角色添加成功！", true);
                }
                else
                {
                    return new BaseResult<RoleEntity>("角色添加失败！", false);
                }
            }
            else
            {
                return new BaseResult<RoleEntity>("角色不可重复添加！", false);
            }

        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<BaseResult<bool>> DelRoleId(Guid guid)
        {
            var roleListEntity = _redisUtil.GetTVlues<RoleEntity>(_redisUtil.Role(guid));
            if (roleListEntity == null)
            {
                var total = await _roleRepository.DeleteAsync(roleListEntity);
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
    }
}
