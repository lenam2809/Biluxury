using BILUXURY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BILUXURY.Areas.Admin
{
    public class QLDonHangController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        // GET: Admin/QLDonHang
        public ActionResult Index()
        {
            var dsdh = (from p in data.DONHANGs
                         select p).ToList();
            return View(dsdh);
        }

        // GET: Admin/QLDonHang/Details/5
        public ActionResult Details(int id)
        {
            var ctdh = (from p in data.CHITIETDONHANGs where p.MaDH == 1
                        select p).ToList();
            ViewBag.MaDH = id;
            return View(ctdh);
        }

        //// GET: Admin/QLDonHang/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Admin/QLDonHang/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Admin/QLDonHang/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Admin/QLDonHang/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Admin/QLDonHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/QLDonHang/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
