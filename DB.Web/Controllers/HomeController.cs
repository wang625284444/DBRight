using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Entity.Model;
using DB.IService;
using DB.Utils.Common;
using DB.Utils.Extend;
using DB.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DB.Web.Controllers
{
    public class HomeController : DBController
    {
        #region 构造函数
        private IUserRoleService _userRoleService { get; set; }

        private IModuleService _moduleService { get; set; }
        private IRoleService _roleService { get; set; }
        private IRoleModuleService _roleModuleService { get; set; }
        private IRoleButtionService _roleButtionService { get; set; }
        private IModuleButtionService _moduleButtionService { get; set; }
        private HttpContextUtil _httpContextUtil { get; set; }
        public HomeController(IUserRoleService userRoleService, IModuleService moduleService, IRoleService roleService, IRoleModuleService roleModuleService, IRoleButtionService roleButtionService, IModuleButtionService moduleButtionService, HttpContextUtil httpContextUtil)
        {
            this._userRoleService = userRoleService;
            this._moduleService = moduleService;
            this._roleService = roleService;
            this._httpContextUtil = httpContextUtil;
            this._roleButtionService = roleButtionService;
            this._moduleButtionService = moduleButtionService;
            this._roleModuleService = roleModuleService;
        }
        #endregion
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 查询角色权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Query()
        {
            //根据用户获取角色关系
            var _userRole = await _userRoleService.userRoleSessionById();
            //获取角色
            var _roleList = await _roleService.QueryById(_userRole.data.RoleId);

            //获取全部按钮
            var _moduleButtionList = await _moduleButtionService.QueryAllList();
            //根据角色获取按钮关系
            var _roolebuttion = await _roleButtionService.QueryByRoleListID(_roleList.data.Id, _moduleButtionList.data.ToList());
            //获取模块信息
            var _roleModul = await _roleModuleService.QueryByRoleId(_roleList.data.Id);
            //将角色数据转换成数组
            var _rolemodelList = _roleModul.data.Select(x => x.ModuleId).ToArray();
            //根据角色获取的权限信息查找权限
            var _modulelist = await _moduleService.QueryInId(_rolemodelList, _roleList.data.Id);
            Guid guid = new Guid("00000000-0000-0000-0000-000000000000");
            //获取集合中的父级数据
            var _listtree = _modulelist.dataList.Where(e => e.Pid == guid).ToList();
            //装载tree数据集合
            List<HomeModels> treelist = new List<HomeModels>();
            //将父级数据写入TreeModel模型
            foreach (var item in _listtree)
            {
                List<HomeChildren> childrenlist = new List<HomeChildren>();
                HomeModels tree = new HomeModels();
                tree.title = item.UrlName;
                tree.id = item.Id;
                tree.href = item.Url;
                var _listchildren = _modulelist.dataList.Where(e => e.Pid == item.Id).ToList();
                foreach (var Listchil in _listchildren)
                {
                    HomeChildren children = new HomeChildren();
                    children.id = Listchil.Id;
                    children.title = Listchil.UrlName;
                    children.href = Listchil.Url;
                    childrenlist.Add(children);
                }
                tree.children = childrenlist;
                treelist.Add(tree);
            }
            return JsonDateTime(treelist);
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult LoginUser()
        {
            var username = _httpContextUtil.GetSession<UserEntity>(KeyUtil.user_info);

            return Json(username);
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult QuitLanding()
        {
            _httpContextUtil.RemoveSession(KeyUtil.user_info);
            return Json("true");
        }
    }
}