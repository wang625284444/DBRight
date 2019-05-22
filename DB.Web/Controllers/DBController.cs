using DB.Entity.Model;
using DB.Entity.Response;
using DB.Utils.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Linq;

namespace DB.Web.Controllers
{
    public class DBController : Controller
    {
        /// <summary>
        /// 停止请求
        /// </summary>
        public class NoPermissionRequiredAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                base.OnActionExecuting(filterContext);
            }

        }
        /// <summary>
        /// 请求过滤处理
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var isDefined = false;
            //创建一个行动限制ActionDescriptor
            var controllerActionDescriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;
            //执行方法是否存在NoPermissionRequired
            if (controllerActionDescriptor != null)
            {
                isDefined = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true).Any(a => a.GetType().Equals(typeof(NoPermissionRequiredAttribute)));
            }
            //判断是否拦截
            if (isDefined) return;
            byte[] result;
            //获取session
            filterContext.HttpContext.Session.TryGetValue(KeyUtil.user_info, out result);
            //判断session是否存在
            if (result == null)
            {
                //跳转到登陆页面
                filterContext.Result = RedirectToAction("Index", "Signin");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
       
        /// <summary>
        /// 封装条件验证未通过的返回实体
        /// </summary>
        /// <returns></returns>
        public BaseResult<bool> ParrNoPass()
        {
            return new BaseResult<bool>(800, false);
        }
        /// <summary>
        /// 读取用户信息
        /// </summary>
        public UserEntity GetUserSession { get; private set; }
        /// <summary>
        /// 登录用户session读取
        /// </summary>
        /// <returns></returns>
        private UserEntity getUserSession()
        {
            try
            {
                string userJson = HttpContext.Session.GetString(KeyUtil.user_info);
                if (string.IsNullOrEmpty(userJson))
                {
                    return null;
                }
                UserEntity GetUserSession = JsonNetHelper.DeserializeObject<UserEntity>(userJson);
                return GetUserSession;
            }
            catch (System.Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// 获取当前登陆人角色权限关系
        /// </summary>
        public RoleButtionEntity GetRoleButtionSession { get; private set; }
       
        /// <summary>
        /// 重构方法(如果给前台响应日期时间调用此方法方法)
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public ContentResult JsonDateTime(object result)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return Content(JsonConvert.SerializeObject(result, Formatting.Indented, timeConverter));
        }

        /// <summary>
        /// 重构方法json
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public ContentResult JsonData(object result)
        {
            return Content(JsonConvert.SerializeObject(result, Formatting.Indented));
        }
    }
}
