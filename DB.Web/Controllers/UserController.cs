using System;
using System.Threading.Tasks;
using DB.Entity.Model;
using DB.IService;
using DB.Utils.Common;
using Microsoft.AspNetCore.Mvc;

namespace DB.Web.Controllers
{
    public class UserController : DBController
    {
        public IUserService _usersService { get; private set; }
        public UserController(IUserService userService)
        {
            _usersService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="userEntity"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> QueryUser(UserEntity userEntity, int page, int limit)
        {
            var userList = await _usersService.QueryUser(userEntity, page, limit);
            return Json(userList);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        public async Task<ActionResult> AddUser(UserEntity userEntity)
        {
            userEntity.Id = Guid.NewGuid();
            userEntity.UserNumber = "YH" + DateTime.Now.ToString("yyyyMMddss");
            return Json(await _usersService.AddUser(userEntity));
        }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        public async Task<ActionResult> ModifyUser(UserEntity userEntity)
        {
            return Json(await _usersService.ModifyUser(userEntity));
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<ActionResult> DelUserId(string obj)
        {
            return Json(await _usersService.DelUserId(obj));
        }
        /// <summary>
        /// 更改用户状态
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<ActionResult> UpdateStatusUserId(Guid guid)
        {
            return Json(await _usersService.UpdateStatusUserId(guid));
        }

    }
}