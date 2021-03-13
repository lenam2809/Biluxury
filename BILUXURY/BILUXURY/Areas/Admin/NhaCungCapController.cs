using BILUXURY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BILUXURY.Areas.Admin
{
    public class NhaCungCapController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        // GET: Admin/NhaCungCap
        public ActionResult Index()
        {
            var dsncc = (from n in data.NHACUNGCAPs
                          select n).ToList();
            return View(dsncc);
        }

        // GET: Admin/NhaCungCap/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhaCungCap/Create
        [HttpPost]
        public ActionResult Create(NHACUNGCAP collection)
        {
            try
            {
                // TODO: Add insert logic here
                data.NHACUNGCAPs.InsertOnSubmit(collection);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NhaCungCap/Edit/5
        public ActionResult Edit(int id)
        {
            var n = data.NHACUNGCAPs.Single(s => s.MaNCC == id);
            return View(n);
        }

        // POST: Admin/NhaCungCap/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, NHACUNGCAP collection)
        {
            try
            {
                // TODO: Add update logic here
                NHACUNGCAP n = data.NHACUNGCAPs.Single(s => s.MaNCC == id);
                n.TenNCC = collection.TenNCC;
                n.DiaChi = collection.DiaChi;
                n.Phone = collection.Phone;
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NhaCungCap/Delete/5
        public ActionResult Delete(int id)
        {
            var n = data.NHACUNGCAPs.Single(s => s.MaNCC == id);
            return View(n);
        }

        // POST: Admin/NhaCungCap/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, NHACUNGCAP collection)
        {
            try
            {
                // TODO: Add delete logic here
                var nDel = data.NHACUNGCAPs.Single(s => s.MaNCC == id);
                data.NHACUNGCAPs.DeleteOnSubmit(nDel);
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
