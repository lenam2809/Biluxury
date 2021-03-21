using BILUXURY.Models;
using System.Linq;
using System.Web.Mvc;

namespace BILUXURY.Areas.Admin
{
    public class FeedbackController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();

        // GET: Admin/Feedback
        public ActionResult Index()
        {
            var fb = (from p in data.FEEDBACKs
                      select p).ToList();
            return View(fb);
        }

        // GET: Admin/Feedback/Details/5
        public ActionResult Details(int id)
        {
            var fb = data.FEEDBACKs.Single(s => s.ID == id);
            return View(fb);
        }
    }
}
