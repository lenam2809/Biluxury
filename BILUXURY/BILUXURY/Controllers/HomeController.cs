using BILUXURY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BILUXURY.Controllers
{
    public class HomeController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Index()
        {
            var lsp = (from p in data.LOAISANPHAMs
                      select p).ToList().Take(5);
            ViewBag.list = lsp;

            var sp = data.SANPHAMs.OrderByDescending(x => x.Gia).ToList().Take(4);
            ViewBag.listsp = sp;

            var sp2 = data.SANPHAMs.OrderBy(x => x.Gia).ToList().Take(4);
            ViewBag.listsp2 = sp2;

            var news = data.NEWs.OrderByDescending(x => x.ViewCount).ToList().Take(3);
            ViewBag.news = news;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult HTCuaHang()
        {
            return View();
        }
    }
}