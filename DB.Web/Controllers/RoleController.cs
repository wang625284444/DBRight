using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Entity.Model;
using DB.Entity.Response;
using DB.IService;
using DB.Utils.Common;
using Microsoft.AspNetCore.Mvc;

namespace DB.Web.Controllers
{
    public class RoleController : DBController
    {
        public IRoleModuleService _roleModuleService { get; private set; }
        public IRoleService _roleService { get; private set; }

        public RoleController(IRoleService roleService, IRoleModuleService roleModuleService)
        {
            this._roleService = roleService;
            this._roleModuleService = roleModuleService;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 根据用户ID查询角色
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetQuery()
        {
            var user = GetUserSession;
            var list = await _roleModuleService.QueryById(user.Id);
            string json = JsonNetHelper.SerializeObject(list);
            return Json(json);
        }
        /// <summary>
        /// 查询角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> QueryRole(RoleEntity roleEntity, int page, int limit)
        {
            return Json(await _roleService.QueryRole(roleEntity, page, limit));
        }
        /// <summary>
        /// 查询Id和RoleName信息
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public async Task<IActionResult> QueryRoleEffective(string roleName)
        {
            var list = await _roleService.QueryRoleEffective();
            return Json(list.data.Select(x => new { x.Id, x.RoleName, x.Pid }));
        }
        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="roleEntity"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddRole(RoleEntity roleEntity)
        {
            return Json(await _roleService.AddRole(roleEntity));
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<IActionResult> DelRoleId(string obj)
        {
            return Json(await _roleService.DelRoleId(obj));
        }
    }
}