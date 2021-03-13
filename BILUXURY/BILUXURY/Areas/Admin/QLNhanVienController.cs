using BILUXURY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BILUXURY.Areas.Admin
{
    public class QLNhanVienController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();

        // GET: Admin/QLNhanVien
        public ActionResult Index()
        {
            var dsnv = (from p in data.NHANVIENs
                        select p).ToList();
            return View(dsnv);
        }

        // GET: Admin/QLNhanVien/Details/5
        public ActionResult Details(int id)
        {
            var nv = data.NHANVIENs.Single(s => s.MaNV == id);
            return View(nv);
        }

        // GET: Admin/QLNhanVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QLNhanVien/Create
        [HttpPost]
        public ActionResult Create(NHANVIEN collection)
        {
            try
            {
                // TODO: Add insert logic here
                data.NHANVIENs.InsertOnSubmit(collection);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/QLNhanVien/Edit/5
        public ActionResult Edit(int id)
        {
            var nv = data.NHANVIENs.Single(s => s.MaNV == id);
            return View(nv);
        }

        // POST: Admin/QLNhanVien/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, NHANVIEN collection)
        {
            try
            {
                // TODO: Add update logic here
                NHANVIEN Sp = data.NHANVIENs.Single(s => s.MaNV == id);
                Sp.TenNV = collection.TenNV;
                Sp.NgaySinh = collection.NgaySinh;
                Sp.DiaChi = collection.DiaChi;
                Sp.GioiTinh = collection.GioiTinh;
                Sp.GhiChu = collection.GhiChu;
                Sp.Account = collection.Account;
                Sp.Password = collection.Password;
                Sp.IsActive = collection.IsActive;
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/QLNhanVien/Delete/5
        public ActionResult Delete(int id)
        {
            var nv = data.NHANVIENs.Single(s => s.MaNV == id);
            return View(nv);
        }

        // POST: Admin/QLNhanVien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, NHANVIEN collection)
        {
            try
            {
                // TODO: Add delete logic here
                var nvDel = data.NHANVIENs.Single(s => s.MaNV == id);
                data.NHANVIENs.DeleteOnSubmit(nvDel);
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
