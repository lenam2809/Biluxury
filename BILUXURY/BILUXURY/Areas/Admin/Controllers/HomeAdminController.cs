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

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult QLSanPham()
        {
            var sp = (from p in data.SANPHAMs
                      select p).ToList();
            ViewBag.listsp = sp;
            return View();
        }

        public ActionResult AddSanPham()
        {
            return View();
        }

        public ActionResult QLNews()
        {
            return View();
        }

        public ActionResult QLNhanVien()
        {
            return View();
        }

        public ActionResult QLKhachHang()
        {
            return View();
        }

        public ActionResult QLDonHang()
        {
            return View();
        }

        //public ActionResult deleteProduct(int id = -1)
        //{

        //    var sp = data.SANPHAMs.Where(p => p.MaSP == id).FirstOrDefault();
        //    if (sp != null)
        //    {
        //        data.SANPHAMs.DeleteOnSubmit(sp);
        //        data.SANPHAMs.Sa;
        //    }
        //    return RedirectToAction("QLSanPham", "Admin");
        //}
    }
}