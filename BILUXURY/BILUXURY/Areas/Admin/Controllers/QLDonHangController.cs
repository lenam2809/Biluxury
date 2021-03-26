using BILUXURY.Models;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BILUXURY.Areas.Admin
{
    public class QLDonHangController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        // GET: Admin/QLDonHang
        public ActionResult Index(int? page, string sortOrder, int pageSize = 10)
        {
            if (page == null) page = 1;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "giam_dan" : "";
            var dsdh = from p in data.DONHANGs
                        select p;
            switch (sortOrder)
            {
                // 1. Nếu biến sortOrder sắp giảm thì sắp giảm theo NgayDH
                case "giam_dan":
                    dsdh = dsdh.OrderByDescending(s => s.NgayDH);
                    break;
                // 2. Mặc định thì sẽ sắp tăng
                default:
                    dsdh = dsdh.OrderBy(s => s.NgayDH);
                    break;
            }
            int pageNumber = (page ?? 1);
            return View(dsdh.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/QLDonHang/Details/5
        public ActionResult Details(int id)
        {
            var ctdh = (from p in data.CHITIETDONHANGs
                        where p.MaDH == 1
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
