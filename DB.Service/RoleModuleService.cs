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
        public RoleModuleService(IRoleModuleRepository roleModuleRepository)
        {
            this._roleModuleRepository = roleModuleRepository;

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
        /// 查询角色信息
        /// </summary>
        /// <returns>BaseResult</returns>
        public async Task<BaseResult<IQueryable<RoleModuleEntity>>> QueryById(Guid guid)
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
    }
}
