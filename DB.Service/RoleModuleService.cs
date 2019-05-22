using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DB.Entity.Model;
using DB.Entity.Response;
using DB.IRepository.limit;
using DB.IService;
using DB.Utils.Common;
using DB.Utils.Extend;

namespace DB.Service
{
    public class RoleModuleService : IRoleModuleService
    {
        private IRoleModuleRepository _roleModuleRepository { get; set; }
        private HttpContextUtil _httpContextUtil { get; set; }
        public RoleModuleService(IRoleModuleRepository roleModuleRepository, HttpContextUtil httpContextUtil)
        {
            this._roleModuleRepository = roleModuleRepository;
            this._httpContextUtil = httpContextUtil;
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResult<IQueryable<RoleModuleEntity>>> QueryAll()
        {
            Expression<Func<RoleModuleEntity, bool>> where = LinqUtil.True<RoleModuleEntity>();
            where = where.AndAlso(e => e.IsStatus == true);
            IQueryable<RoleModuleEntity> _roleModulelist = await _roleModuleRepository.GetAllAsync(where);
            return new BaseResult<IQueryable<RoleModuleEntity>>(_roleModulelist.AsQueryable());
        }

        /// <summary>
        /// 查询模块关联信息
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<BaseResult<IQueryable<RoleModuleEntity>>> QueryByRoleId(Guid guid)
        {

            Expression<Func<RoleModuleEntity, bool>> where = LinqUtil.True<RoleModuleEntity>();
            where = where.AndAlso(e => e.RoleId == guid && e.IsStatus == true);
            IQueryable<RoleModuleEntity> _roleModulelist = await _roleModuleRepository.GetAllAsync(where);
            return new BaseResult<IQueryable<RoleModuleEntity>>(_roleModulelist.AsQueryable());
        }

        /// <summary>
        /// 添加角色权限
        /// </summary>
        /// <param name="roleModuleList"></param>
        /// <returns></returns>
        public async Task<BaseResult<bool>> AddModuleList(string obj)
        {
            List<RoleModuleEntity> roleModuleList = JsonNetHelper.DeserializeObject<List<RoleModuleEntity>>(obj);
            if (await _roleModuleRepository.AddListAsync(roleModuleList))
            {
                return new BaseResult<bool>("模块保存成功！");
            }
            else
            {
                return new BaseResult<bool>("模块保存失败！", false);
            }
        }

        /// <summary>
        /// 根据角色删除全部权限关系
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<BaseResult<bool>> DelModuleList(Guid guid)
        {
            Expression<Func<RoleModuleEntity, bool>> where = LinqUtil.True<RoleModuleEntity>();
            where = where.AndAlso(e => e.RoleId == guid);
            var roleModuleEntities = await _roleModuleRepository.GetAllAsync(where);
            if (await _roleModuleRepository.DeleteListAsync(roleModuleEntities.ToList()))
            {
                return new BaseResult<bool>("删除用户成功！");
            }
            else
            {
                return new BaseResult<bool>("删除用户操作失败！");
            }
        }
    }
}
