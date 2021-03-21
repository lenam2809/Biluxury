using BILUXURY.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BILUXURY.Controllers
{
    public class SearchInfoController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();

        // GET: SearchInfo
        [HttpGet]
        public ActionResult Index(string searchString)
        {
            var sp = from s in data.SANPHAMs // lấy toàn bộ liên kết
                     select s;

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                sp = sp.Where(s => s.TenSP.Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }

            return View(sp); //trả về kết quả


        }
    }
}