using BILUXURY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BILUXURY.Areas.Admin
{
    public class LoaiSPController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();

        // GET: Admin/LoaiSP
        public ActionResult Index()
        {
            var lsp = (from n in data.LOAISANPHAMs
                         select n).ToList();
            return View(lsp);
        }

        // GET: Admin/LoaiSP/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSP/Create
        [HttpPost]
        public ActionResult Create(LOAISANPHAM collection)
        {
            try
            {
                // TODO: Add insert logic here
                data.LOAISANPHAMs.InsertOnSubmit(collection);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoaiSP/Edit/5
        public ActionResult Edit(int id)
        {
            var n = data.LOAISANPHAMs.Single(s => s.MaLoaiSP == id);
            return View(n);
        }
 

        // POST: Admin/LoaiSP/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LOAISANPHAM collection)
        {
            try
            {
                // TODO: Add update logic here
                LOAISANPHAM n = data.LOAISANPHAMs.Single(s => s.MaLoaiSP == id);
                n.TenLoaiSP= collection.TenLoaiSP;
                n.MieuTa = collection.MieuTa;
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoaiSP/Delete/5
        public ActionResult Delete(int id)
        {
            var n = data.LOAISANPHAMs.Single(s => s.MaLoaiSP == id);
            return View(n);
        }

        // POST: Admin/LoaiSP/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var nDel = data.LOAISANPHAMs.Single(s => s.MaLoaiSP == id);
                data.LOAISANPHAMs.DeleteOnSubmit(nDel);
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
