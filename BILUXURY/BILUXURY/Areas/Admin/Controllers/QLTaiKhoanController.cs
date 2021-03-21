using BILUXURY.Models;
using System.Linq;
using System.Web.Mvc;

namespace BILUXURY.Areas.Admin.Controllers
{
    public class QLTaiKhoanController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();

        // GET: Admin/QLTaiKhoan
        public ActionResult Index()
        {
            var account = data.TAIKHOANs;
            return View(account);
        }
    }
}
