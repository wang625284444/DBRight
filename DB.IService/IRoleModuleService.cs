﻿using DB.Entity.Model;
using DB.Entity.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.IService
{
    public interface IRoleModuleService
    {
        [Obsolete("方法不再使用")]
        Task<BaseResult<IQueryable<RoleModuleEntity>>> QueryAll();
        /// <summary>
        /// 根据用户ID查询角色
        /// </summary>
        /// <returns></returns>
        Task<BaseResult<IQueryable<RoleModuleEntity>>> QueryById(Guid guid);

        /// <summary>
        /// 添加角色权限
        /// </summary>
        /// <param name="roleModuleList"></param>
        /// <returns></returns>
        Task<BaseResult<bool>> AddModuleList(string obj);
    }
}
