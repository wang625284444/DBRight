using System;
using DB.Entity.Model;
using DB.UnitOfWork.IServices;
using DB.Web.Models;
using Microsoft.AspNetCore.Mvc;


namespace DB.Web.Controllers
{
    public class WorkController : DBController
    {
        private IWorkServices _workServices { get; set; }
        public WorkController(IWorkServices workServices)
        {
            this._workServices = workServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 用户提交数据
        /// </summary>
        [HttpPost]
        public IActionResult UserEstablish(WorkModels work)
        {
            var type = _workServices.GetEntityUpdate<UserEntity>(work.guid, "UserEntity", work.message);
            return Json(type);
        }
        //角色审批
    }
}
