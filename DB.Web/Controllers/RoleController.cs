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
        public IRoleModuleService _roleModuleEntity { get; private set; }
        public IRoleService _roleService { get; private set; }

        public RoleController(IRoleService roleService, IRoleModuleService roleModuleEntity)
        {
            this._roleService = roleService;
            this._roleModuleEntity = roleModuleEntity;
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
            var user = getUserSession();
            var list = await _roleModuleEntity.GetQuery(user.Id);
            string json = JsonNetHelper.SerializeObject(list);
            return Json(json);
        }
        /// <summary>
        /// 查询角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Query()
        {
            var list = await _roleService.Query();
            string json = JsonNetHelper.SerializeObject(list);
            return Json(json);
        }



    }
}