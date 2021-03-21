using BILUXURY.Models;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace BILUXURY.Controllers
{
    public class ViewSanPhamController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();

        // GET: ViewSanPham
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var sp = from p in data.SANPHAMs
                     select p;
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return View(sp.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult DsSP(int id)
        {

            var lsp = data.LOAISANPHAMs.FirstOrDefault(l => l.MaLoaiSP == id);

            ViewBag.lSp = lsp.MieuTa;
            ViewBag.namelsp = lsp.TenLoaiSP;

            var sp = from s in data.SANPHAMs
                     where s.MaLoaiSP == id
                     select s;
            ViewBag.sp = sp;
            //upload image
            return View();
        }

        public ActionResult Detail(int id)
        {
            var sp = data.SANPHAMs.Single(s => s.MaSP == id);
            ViewBag.image = sp.LinkAnh;
            ViewBag.masp = sp.MaSP;
            ViewBag.tensp = sp.TenSP;
            ViewBag.gia = sp.Gia;
            ViewBag.kd = sp.KieuDang;
            ViewBag.cl = sp.ChatLieu;


            var dsnew = data.NEWs.Where(x => x.MaLSP == sp.MaLoaiSP).ToList();
            ViewBag.news = dsnew;

            var dssp = data.SANPHAMs.Where(x => x.MaLoaiSP == sp.MaLoaiSP).ToList();
            ViewBag.lsp = dssp;

            return View();
        }
    }
}