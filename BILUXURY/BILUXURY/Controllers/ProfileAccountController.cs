using BILUXURY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BILUXURY.Controllers
{
    public class ProfileAccountController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();

        // GET: ProfileAccount/Index/5
        public ActionResult Index(int id)
        {
            var profile = data.KHACHHANGs.FirstOrDefault(p => p.MaKH == id);
            ViewBag.TenKH = profile.TenKH;
            ViewBag.MaKH = profile.MaKH;
            ViewBag.NgaySinh = profile.NgaySinh;
            ViewBag.DiaChi = profile.DiaChi;
            ViewBag.GioiTinh = profile.GioiTinh;
            ViewBag.Phone = profile.Phone;
            ViewBag.Email = profile.Email;


            var JoinDH = from d in data.DONHANGs
                         join c in data.CHITIETDONHANGs
                         on d.MaDH equals c.MaDH
                         select new { d.MaKH, c.MaSP, c.SoLuong };

            var JoinSP = from a in JoinDH
                         join s in data.SANPHAMs
                         on a.MaSP equals s.MaSP
                         select new LSThanhToan { MaKH = a.MaKH, MaSP = a.MaSP, TenSP = s.TenSP, SoLuong = a.SoLuong, Gia = Convert.ToDecimal(s.Gia) };
            var chitietDH = JoinSP.Where(p => p.MaSP == id);
            ViewBag.donhang = chitietDH;


            return View();
        }


        public ActionResult Edit(int id)
        {
            var proffile = data.KHACHHANGs.Where(p => p.MaKH == id);
            return View(proffile);
        }

        // POST: ProfileAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, KHACHHANG  collection)
        {
            try
            {
                // TODO: Add update logic here
                KHACHHANG Sp = data.KHACHHANGs.Single(s => s.MaKH == id);
                Sp.TenKH = collection.TenKH;
                Sp.NgaySinh = collection.NgaySinh;
                Sp.DiaChi = collection.DiaChi;
                Sp.Email = collection.Email;
                Sp.GioiTinh = collection.GioiTinh;
                Sp.Phone = collection.Phone;
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult LichSuThanhToan(int id)
        {
            var donhang = data.DONHANGs.Where(p => p.MaKH == id);
            return View(donhang);
        }


    }
}
