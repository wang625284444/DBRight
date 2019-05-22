using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.IService;
using DB.Utils.Common;
using DB.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DB.Web.Controllers
{
    public class ModuleController : DBController
    {

        private IModuleService _moduleService { get; set; }
        private IRoleModuleService _roleModuleService { get; set; }
        public ModuleController(IModuleService moduleService, IRoleModuleService roleModuleService)
        {
            this._moduleService = moduleService;
            this._roleModuleService = roleModuleService;
        }

        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 查询全部模块
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Query()
        {

            Guid guid = new Guid("00000000-0000-0000-0000-000000000000");
            //装载tree数据集合
            List<ModuleModels> treelist = new List<ModuleModels>();
            List<ModuleChildren> childrenlist = new List<ModuleChildren>();
            var _modulelist = await _moduleService.Query();
            var _listtree = _modulelist.data.Where(e => e.Pid == guid).ToList();
            foreach (var item in _listtree)
            {
                ModuleModels tree = new ModuleModels();
                tree.leaf = false;
                tree.text = item.UrlName;
                tree.@checked = false;
                tree.data = "";
                var _listchildren = _modulelist.data.Where(e => e.Pid == item.Id).ToList();
                foreach (var Listchil in _listchildren)
                {
                    ModuleChildren children = new ModuleChildren();
                    children.@checked = false;
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

        ///// <summary>
        ///// 根据角色Id获取用户模块
        ///// </summary>
        ///// <param name="guids"></param>
        ///// <returns></returns>
        //public async Task<ActionResult> QueryInId(Guid guid)
        //{
        //    var _roleModul = await _roleModuleService.QueryByRoleId(guid);
        //    return JsonDateTime(await _moduleService.QueryInId(_roleModul.data.Select(x => x.ModuleId).ToArray()));
        //}
    }
}