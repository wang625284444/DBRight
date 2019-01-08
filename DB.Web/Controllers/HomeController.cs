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
            var _roleModul = await _roleModuleService.GetQuery(_roleList.data.Id);
            //将要角色数据转换成数组
            var _rolemodelList = _roleModul.data.Select(x => x.ModuleId).ToArray();
            //根据角色获取的权限信息查找权限
            var _userlist = await _moduleService.QueryInId(_rolemodelList);
            Guid guid = new Guid("00000000-0000-0000-0000-000000000000");
            //装载tree数据集合
            List<TreeModels> treelist = new List<TreeModels>();
            List<Children> childrenlist = new List<Children>();
            //获取集合中的父级数据
            var _listtree = _userlist.dataList.Where(e => e.Pid == guid).ToList();
            //将父级数据写入TreeModel模型
            foreach (var item in _listtree)
            {
                TreeModels tree = new TreeModels();
                //tree.id = item.Id;
                tree.leaf = false;
                tree.text = item.UrlName;
                tree.data = "";
                //tree.parentId = item.Pid;
                var _listchildren = _userlist.dataList.Where(e => e.Pid == item.Id).ToList();
                foreach (var Listchil in _listchildren)
                {
                    Children children = new Children();
                    children.id = Listchil.Id;
                    children.leaf = true;
                    children.text = Listchil.UrlName;
                    //children.data = "<iframe width='100%' height='100%' frameborder='0'  src=" + Listchil.Url + " style='width:100%;height:100%;margin:0px 0px;'></iframe>";
                    children.url = Listchil.Url;
                    //if (Listchil.Url != null)
                    //{
                    //    Attributes attr = new Attributes();
                    //    attr.url = "<iframe width='100%' height='100%' frameborder='0'  src=" + Listchil.Url + " style='width:100%;height:100%;margin:0px 0px;'></iframe>";
                    //    children.attributes = attr;
                    //}
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