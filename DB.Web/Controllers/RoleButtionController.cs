using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Entity.Model;
using DB.IService;
using DB.Utils.Common;
using Microsoft.AspNetCore.Mvc;

namespace DB.Web.Controllers
{
    public class RoleButtionController : DBController
    {
        private IRoleButtionService _roleButtionService { get; set; }
        public RoleButtionController(IRoleButtionService roleButtionService)
        {
            this._roleButtionService = roleButtionService;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 根据角色ID查询按钮
        /// </summary>
        /// <param name="guid">角色ID</param>
        /// <returns></returns>
        public async Task<IActionResult> QueryByRoleID(Guid guid)
        {
            var list = await _roleButtionService.QueryByRoleID(guid);
            return JsonDateTime(list.data.Select(x => new { x.ModuleButtionId }));
        }
        ///// <summary>
        ///// 批量删除关联信息
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns></returns>
        //public async Task<IActionResult> DelByRoleID(Guid[] obj)
        //{
        //    return Json(await _roleButtionService.DelByRoleID(obj));
        //}
    }
}