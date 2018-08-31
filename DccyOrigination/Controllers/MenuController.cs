using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DccyOrigination.EF;
using DccyOrigination.Models;
using Microsoft.AspNetCore.Mvc;

namespace DccyOrigination.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetLeftMenuTreeData()
        {
   
            return Json(new
            {
                StateCode = 200,
                Message = "请求成功",
                Data =""
            });
         
        }
    }
}