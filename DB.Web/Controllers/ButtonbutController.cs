using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DB.Web.Controllers
{
    public class ButtonbutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取角色当前页面按钮
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Rolebuttion(string url)
        {
            return null;
        }
    }
}