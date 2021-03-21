using BILUXURY.Models;
using System.Linq;
using System.Web.Mvc;

namespace BILUXURY.Areas.Admin
{
    public class QLKhachHangController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();

        // GET: Admin/QLKhachHang
        public ActionResult Index()
        {
            var dskh = (from p in data.KHACHHANGs
                        select p).ToList();
            return View(dskh);
        }

        // GET: Admin/QLKhachHang/Details/5
        public ActionResult Details(int id)
        {
            var kh = data.KHACHHANGs.Single(s => s.MaKH == id);
            return View(kh);
        }

        // GET: Admin/QLKhachHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QLKhachHang/Create
        [HttpPost]
        public ActionResult Create(KHACHHANG collection)
        {
            try
            {
                // TODO: Add insert logic here
                data.KHACHHANGs.InsertOnSubmit(collection);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/QLKhachHang/Edit/5
        public ActionResult Edit(int id)
        {
            var kh = data.KHACHHANGs.Single(s => s.MaKH == id);
            return View(kh);
        }

        // POST: Admin/QLKhachHang/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, KHACHHANG collection)
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

        // GET: Admin/QLKhachHang/Delete/5
        public ActionResult Delete(int id)
        {
            var kh = data.KHACHHANGs.Single(s => s.MaKH == id);
            return View(kh);
        }

        // POST: Admin/QLKhachHang/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, KHACHHANG collection)
        {
            try
            {
                // TODO: Add delete logic here
                var khDel = data.KHACHHANGs.Single(s => s.MaKH == id);
                var account = data.TAIKHOANs.FirstOrDefault(s => s.Email == khDel.Email);
                data.TAIKHOANs.DeleteOnSubmit(account);
                data.SubmitChanges();

                data.KHACHHANGs.DeleteOnSubmit(khDel);
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
