
using DB.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DB.Web.Controllers
{
    public class RoleModuleController : DBController
    {
        private IRoleModuleService _roleModuleService { get; set; }

        private IModuleButtionService _moduleButtionService { get; set; }
        public RoleModuleController(IRoleModuleService roleModuleService, IModuleButtionService moduleButtionService)
        {
            this._roleModuleService = roleModuleService;
            this._moduleButtionService = moduleButtionService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult<bool>> AddModuleToArray(string obj, Guid guid)
        {
            //删除之前的模块关系
            var delroletype = await _roleModuleService.DelModuleList(guid);
            if (delroletype.data)
            {
                return Json(delroletype);
            }
            return Json(await _roleModuleService.AddModuleList(obj));
        }
    }
}