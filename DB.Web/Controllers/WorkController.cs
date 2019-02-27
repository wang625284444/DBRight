using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.UnitOfWork;
using Microsoft.AspNetCore.Mvc;


namespace DB.Web.Controllers
{
    public class WorkController : DBController
    {
        private Workreflex _workBusiness { get; set; }
        public WorkController(Workreflex workBusiness)
        {
            this._workBusiness = workBusiness;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult WorkEstablish(string establish, Guid guid)
        {
            _workBusiness.Establish(establish, guid);
            return null;
        }
    }
}
