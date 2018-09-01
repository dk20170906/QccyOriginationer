using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DccyOrigination.EF;
using DccyOrigination.Models;
using DccyOrigination.Models.Result;
using DccyOrigination.Models.SysManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DccyOrigination.Controllers
{
    public class MenuController : Controller
    {

        /// <summary>
        /// 用户根节点集合
        /// </summary>
        private List<LeftMenu> RootMenu = new List<LeftMenu>();
        /// <summary>
        ///        根节点菜单guid集合
        /// </summary>
        private List<string> rootmenuguids = new List<string>();
        public IActionResult Index ()
        {
            return View();
        }

        /// <summary>
        /// 得到用户所在部门与角色中的菜单ids
        /// </summary>
        /// <param name="admUser"></param>
        /// <returns></returns>
        private List<string> GetMenuGuidByUserRoleIdORDepId (AdmUser admUser)
        {
            List<string> menuids = new List<string>();
            Task taskdep = DBHandler.Db.AdmDepartment.Where(u => u.Id == admUser.DepId).AsQueryable().ForEachAsync(m =>
            {
                if (m.IsDelete == false && !menuids.Contains(m.MenuGuid))
                {
                    menuids.Add(m.MenuGuid);
                }
            });
            Task taskrole = DBHandler.Db.AdmRole.Where(u => u.Id == admUser.RoleId).AsQueryable().AsQueryable().ForEachAsync(m =>
            {
                if (m.IsDelete == false && !menuids.Contains(m.MenuGuid))
                {
                    menuids.Add(m.MenuGuid);
                }
            });
            Task.WaitAll(taskdep, taskrole);
            return menuids;
        }


        /// <summary>
        /// 生成左侧菜单
        /// </summary>
        /// <returns></returns>
        public JsonResult GetLeftMenuTreeData ()
        {
            /// <summary>
            /// 用户菜单集合
            /// </summary>
            List<LeftMenu> MenuList = new List<LeftMenu>();
            string userSession = HttpContext.Session.GetString("AdmUserSession");
            if (!string.IsNullOrEmpty(userSession) && JsonConvert.DeserializeObject<AdmUser>(userSession).Id > 0)
            {
                AdmUser admUser = JsonConvert.DeserializeObject<AdmUser>(HttpContext.Session.GetString("AdmUserSession"));
                if (admUser != null && admUser.Id > 0)
                {
                    List<string> menuguids = GetMenuGuidByUserRoleIdORDepId(admUser);
                    if (menuguids.Count > 0)
                    {
                        //清空根节点guid集合
                        rootmenuguids.Clear();
                        var Menus = DBHandler.Db.LeftMenu.Where(s => menuguids.Select(o => o).Any(e => s.IsDelete != false && s.Guid == e)).ToList();
                        if (Menus != null && Menus.Count > 0)
                        {
                            Menus.ForEach(u =>
                            {
                                GetRootMenus(Menus, u);
                            });
                            if (RootMenu.Count > 0)
                            {
                                RootMenu.ForEach(u =>
                                {
                                    MenuList.Add(CreateMenuTree(Menus, u));
                                });
                            }
                            else
                            {
                                return Json(new
                                {
                                    StateCode = (int)ResultEnum.操作失败,
                                    Message = "此用户暂无任何权限，请及时联系管理员！！！"
                                });
                            }
                        }
                    }
                    else
                    {
                        return Json(new
                        {
                            StateCode = (int)ResultEnum.未登录,
                            Message = "请选登录"
                        });
                    }
                }
            }
            return Json(new
            {
                StateCode = (int)ResultEnum.操作成功,
                Message = "请求成功",
                Data = MenuList
            });

        }

        /// <summary>
        /// 向上找根节点
        /// </summary>
        /// <param name="menulist"></param>
        /// <returns></returns>
        /// 
        private void GetRootMenus (List<LeftMenu> menulist, LeftMenu leftMenu)
        {
            if (menulist.Count > 0)
            {
                var menu = menulist.First(u => u.Guid == leftMenu.PGuid);
                if (menu != null && menu.Id > 0)
                {
                    GetRootMenus(menulist, menu);
                }
                else
                {
                    if (!rootmenuguids.Contains(leftMenu.Guid))
                    {
                        rootmenuguids.Add(leftMenu.Guid);
                        RootMenu.Add(leftMenu);
                    }
                }
            }
        }
        /// <summary>
        /// 由根节点向下构建树
        /// </summary>
        /// <param name="menulist"></param>
        /// <param name="leftMenu"></param>
        /// <returns></returns>
        private LeftMenu CreateMenuTree (List<LeftMenu> menulist, LeftMenu leftMenu)
        {
            if (menulist.Count > 0)
            {
                List<LeftMenu> listm = menulist.Where(u => u.PGuid == leftMenu.Guid).ToList();
                if (listm != null && listm.Count > 0)
                {
                    leftMenu.Children = listm;
                    listm.ForEach(m =>
                    {
                        CreateMenuTree(menulist, m);
                    });
                }
                else
                {
                    leftMenu.Children = new List<LeftMenu>();
                }

            }
            return leftMenu;
        }
    }
}