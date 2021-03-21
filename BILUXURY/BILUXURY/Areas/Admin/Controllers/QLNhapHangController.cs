using BILUXURY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BILUXURY.Areas.Admin.Controllers
{
    public class QLNhapHangController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();

        // GET: Admin/QLNhapHang
        public ActionResult Index()
        {
            var hang = data.NhapHangs;
            return View(hang);
        }


        // GET: Admin/QLNhapHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QLNhapHang/Create
        [HttpPost]
        public ActionResult Create(NhapHang collection)
        {
            try
            {
                // TODO: Add insert logic here
                data.NhapHangs.InsertOnSubmit(collection);
                SANPHAM Sp = data.SANPHAMs.Single(s => s.MaSP == collection.MaSP);
                Sp.SoLuong = (int)(Sp.SoLuong + collection.SoLuong);

                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
