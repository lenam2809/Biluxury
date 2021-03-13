using BILUXURY.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BILUXURY.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {

        DataClasses1DataContext data = new DataClasses1DataContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Login(string user, string password)
        {
            if (user=="admin" && password=="123456") // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                return RedirectToAction("Index"); //lọc theo chuỗi tìm kiếm
            }
            return View();
        }

    }
}