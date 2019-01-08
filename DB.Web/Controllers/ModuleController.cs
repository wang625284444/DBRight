using System;
using System.Threading.Tasks;
using DB.IService;
using Microsoft.AspNetCore.Mvc;

namespace DB.Web.Controllers
{
    public class ModuleController : DBController
    {

        public IModuleService _moduleService { get; private set; }
        public ModuleController(IModuleService moduleService)
        {
            this._moduleService = moduleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Signin()
        {
            return Json(await _moduleService.Query());
        }
    }
}