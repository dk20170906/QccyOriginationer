using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DccyOrigination.EF;
using DccyOrigination.Models;
using DccyOrigination.Models.SysManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DccyOrigination.Controllers
{
    public class MenuController : Controller
    {
        /// <summary>
        /// 用户菜单集合
        /// </summary>
        public static List<LeftMenu> MenuList = new List<LeftMenu>();
        /// <summary>
        /// 用户根节点集合
        /// </summary>
        public static List<LeftMenu> RootMenu = new List<LeftMenu>();
        List<string> menuguids = new List<string>();
        public IActionResult Index ()
        {
            return View();
        }


        private List<string> GetMenuGuidByUserRoleIdORDepId (AdmUser admUser)
        {
        var m=  DBHandler.Db.AdmDepartment.Select(u=> {
              if (u.Id==admUser.DepId)
              {
                  return u.Id;
              }
          });
            DBHandler.Db.AdmRole.Where(u => u.Id == admUser.RoleId
        }
        public JsonResult GetLeftMenuTreeData ()
        {

            AdmUser admUser = JsonConvert.DeserializeObject<AdmUser>(HttpContext.Session.GetString("AdmUserSession"));
            if (MenuList != null && MenuList.Count > 0)
            {
                MenuList.Clear();
                menuguids.Clear();
                List<LeftMenu> Menus = DBHandler.Db.LeftMenu.Where(u => u.DepId == admUser.DepId || u.RoleId == admUser.RoleId).ToList();
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
                            StateCode = 300,
                            Message = "此用户暂无任何权限，请及时联系管理员！！！"
                        });
                    }
                }

            }
            return Json(new
            {
                StateCode = 200,
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
                    if (!menuguids.Contains(leftMenu.Guid))
                    {
                        menuguids.Add(leftMenu.Guid);
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