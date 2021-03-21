using BILUXURY.Models;
using System.Linq;
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
            var news = data.NEWs.Single(s => s.ID == id);
            ViewBag.id = news.ID;
            ViewBag.title = news.TieuDe;
            ViewBag.image = news.LinkAnh;
            ViewBag.content = news.NoiDung;
            ViewBag.created = news.NgayTao;

            var dsnews = (from p in data.NEWs
                          select p).ToList();
            ViewBag.dsnews = dsnews;
            return View();
        }
    }
}