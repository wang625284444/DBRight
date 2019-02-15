
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

        private IRoleButtionService _roleButtionService { get; set; }
        public RoleModuleController(IRoleModuleService roleModuleService, IModuleButtionService moduleButtionService, IRoleButtionService roleButtionService)
        {
            this._roleModuleService = roleModuleService;
            this._moduleButtionService = moduleButtionService;
            this._roleButtionService = roleButtionService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult<bool>> AddModuleToArray(string obj, Guid guid, string buttions)
        {
            //删除之前的模块关系
            var delroletype = await _roleModuleService.DelModuleList(guid);
            if (delroletype.data)
            {
                return Json(delroletype);
            }
            //创建角色和模块关系
            var addmodule = await _roleModuleService.AddModuleList(obj);
            if (addmodule.data)
            {
                return Json(addmodule);
            }
            var rolebuttion = await _roleButtionService.DelByRoleID(guid);
            if (rolebuttion.data)
            {
                return Json(addmodule);
            }
            return Json(await _roleButtionService.AddRoleButtion(guid, buttions));
        }
    }
}