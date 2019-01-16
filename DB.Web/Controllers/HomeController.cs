using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private IModuleService _moduleService { get; set; }
        private IRoleService _roleService { get; set; }
        private IRoleModuleService _roleModuleService { get; set; }
        private HttpContextUtil _httpContextUtil { get; set; }
        public HomeController(IModuleService moduleService, IRoleService roleService, IRoleModuleService roleModuleService, HttpContextUtil httpContextUtil)
        {
            this._moduleService = moduleService;
            this._roleService = roleService;
            this._httpContextUtil = httpContextUtil;
            this._roleModuleService = roleModuleService;
        }
        #endregion
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Query()
        {
            //根据用户获取角色
            var _roleList = await _roleService.QueryById();
            //根据角色获取权限
            var _roleModul = await _roleModuleService.QueryById(_roleList.data.Id);
            //将角色数据转换成数组
            var _rolemodelList = _roleModul.data.Select(x => x.ModuleId).ToArray();
            //根据角色获取的权限信息查找权限
            var _modulelist = await _moduleService.QueryInId(_rolemodelList);
            Guid guid = new Guid("00000000-0000-0000-0000-000000000000");
            //装载tree数据集合
            List<HomeModels> treelist = new List<HomeModels>();
            List<HomeChildren> childrenlist = new List<HomeChildren>();
            //获取集合中的父级数据
            var _listtree = _modulelist.dataList.Where(e => e.Pid == guid).ToList();
            //将父级数据写入TreeModel模型
            foreach (var item in _listtree)
            {
                HomeModels tree = new HomeModels();
                tree.leaf = false;
                tree.text = item.UrlName;
                tree.data = "";
                var _listchildren = _modulelist.dataList.Where(e => e.Pid == item.Id).ToList();
                foreach (var Listchil in _listchildren)
                {
                    HomeChildren children = new HomeChildren();
                    children.id = Listchil.Id;
                    children.leaf = true;
                    children.text = Listchil.UrlName;
                    children.url = Listchil.Url;
                    childrenlist.Add(children);
                }
                tree.children = childrenlist;
                treelist.Add(tree);
            }
            return JsonDateTime(treelist);
        }
        [HttpGet]
        public async Task<ActionResult> QuitLanding()
        {
            _httpContextUtil.removeObjectAsJson(KeyUtil.user_info);
            return Json("true");
        }
    }
}