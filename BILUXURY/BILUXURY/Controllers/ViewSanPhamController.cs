using BILUXURY.Models;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BILUXURY.Controllers
{
    public class ViewSanPhamController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();

        // GET: ViewSanPham
        public ActionResult Index(int? page, string searchString = null, int pageSize = 16, int sort = 0)
        {
            if (page == null) page = 1;
            var sp = from p in data.SANPHAMs
                     select p;
            if(!String.IsNullOrEmpty(searchString))
            {
                sp = sp.Where(s => s.TenSP.Contains(searchString));
                
            }

            switch (sort)
            {
                case 1:
                    sp = sp.OrderBy(x => x.Gia);
                    break;
                case 2:
                    sp = sp.OrderByDescending(x => x.Gia);
                    break;
                default:
                    sp = sp.OrderBy(x => x.KhuyenMai);
                    break;
            }

            int pageNumber = (page ?? 1);
            return View(sp.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult DsSP(int id, int? page, int pageSize = 8)
        {
            if (page == null) page = 1;
            var lsp = data.LOAISANPHAMs.FirstOrDefault(l => l.MaLoaiSP == id);

            ViewBag.lSp = lsp.MieuTa;
            ViewBag.namelsp = lsp.TenLoaiSP;


            int pageNumber = (page ?? 1);
            var sp = from s in data.SANPHAMs
                     where s.MaLoaiSP == id
                     select s;
            ViewBag.sp = sp;

            return View(sp.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Detail(int id)
        {
            var sp = data.SANPHAMs.Single(s => s.MaSP == id);
            ViewBag.id = id;
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

        public ActionResult Comment(string comment, int id)
        {
            if (!String.IsNullOrEmpty(comment))
            {
                FEEDBACK fb = new FEEDBACK();
                fb.NoiDung = comment;
                fb.NgayTao = DateTime.Now;
                fb.MaKH = 1;
                data.FEEDBACKs.InsertOnSubmit(fb);
                data.SubmitChanges();
                return RedirectToAction("Detail", new { id = id });
            }
            return RedirectToAction("Detail", new { id = id });
        }
    }
}