using System;
using System.Threading.Tasks;
using DB.IService;
using DB.UnitOfWork;
using DB.Utils.Redis;
using Microsoft.AspNetCore.Mvc;

namespace DB.Web.Controllers
{

    public class SigninController : DBController
    {
        #region 构造函数
        private IUserService _userService { get; set; }

        public SigninController(IUserService userService)
        {
            this._userService = userService;
        }
        #endregion

        #region 首页
        [NoPermissionRequired]
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region 后台用户登录
        [HttpGet]
        [NoPermissionRequired]
        public async Task<ActionResult> Signin(string userAccount, string userPasword)
        {
            var login = await _userService.Login(userAccount, userPasword);
            //ActionExecutingContext filterContext;
            //filterContext.Result = RedirectToAction("Index", "Home");
            //return RedirectToRoute(new { controller = "Home", action = "Index" });
            return Json(login);
        }
        #endregion
    }
}