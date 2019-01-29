using System;
using System.Threading.Tasks;
using DB.IService;
using Microsoft.AspNetCore.Mvc;

namespace DB.Web.Controllers
{
    public class ModuleButtionController : DBController
    {
        private IModuleButtionService _moduleButtionService { get; set; }
        public ModuleButtionController(IModuleButtionService moduleButtionService)
        {
            this._moduleButtionService = moduleButtionService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<bool>> GetModuleButtionById(Guid guid)
        {
            var json = await _moduleButtionService.QueryById(guid);
            return Json(json.data);
        }
    }
}