
using DB.Entity.Model;
using DB.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB.Web.Controllers
{
    public class RoleModuleController : DBController
    {
        private IRoleModuleService _roleModuleService { get; set; }
        public RoleModuleController(IRoleModuleService roleModuleService)
        {
            this._roleModuleService = roleModuleService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult<bool>> AddModuleToArray(string obj)
        {
            return Json(await _roleModuleService.AddModuleList(obj));
        }
    }
}