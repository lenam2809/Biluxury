using BILUXURY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BILUXURY.Controllers
{
    public class ViewNewsController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();

        // GET: News
        public ActionResult Index()
        {
            var dsnews = (from p in data.NEWs
                         select p).ToList();
            ViewBag.dsnews = dsnews;
            return View();
        }

        public ActionResult Detail(int id)
        {
            var news = data.NEWs.Single(s => s.NewID == id);
            ViewBag.id = news.NewID;
            ViewBag.title = news.Title;
            ViewBag.image = news.NewImage;
            ViewBag.content = news.Description;
            ViewBag.created = news.CreatedBy;

            var dsnews = (from p in data.NEWs
                          select p).ToList();
            ViewBag.dsnews = dsnews;
            return View();
        }
    }
}