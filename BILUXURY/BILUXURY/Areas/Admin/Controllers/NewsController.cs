﻿using BILUXURY.Models;
using PagedList;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BILUXURY.Areas.Admin
{
    public class NewsController : Controller
    {

        DataClasses1DataContext data = new DataClasses1DataContext();

        // GET: Admin/News
        public ActionResult Index(int? page, string sortOrder, int pageSize = 10)
        {
            if (page == null) page = 1;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "tang_dan" : "";


            var dsnews = from n in data.NEWs select n;
            switch (sortOrder)
            {
                // 3.1 Nếu biến sortOrder sắp giảm thì sắp giảm theo LinkName
                case "tang_dan":
                    dsnews = dsnews.OrderByDescending(s => s.NgayTao);
                    break;
                // 3.5 Mặc định thì sẽ sắp tăng
                default:
                    dsnews = dsnews.OrderBy(s => s.NgayTao);
                    break;
            }
            int pageNumber = (page ?? 1);
            return View(dsnews.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/News/Details/5
        public ActionResult Details(int id)
        {
            var n = data.NEWs.Single(s => s.ID == id);
            return View(n);
        }

        // GET: Admin/News/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult getData()
        {
            var sp = from e in data.LOAISANPHAMs select new { e.MaLoaiSP, e.TenLoaiSP };
            return Json(sp.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ValidateInput(false)]
        public async Task<string> Upload(HttpPostedFileBase file)
        {
            //validate

            //xu ly upload
            file.SaveAs(Server.MapPath("~/Upload/" + file.FileName));
            await Task.Delay(1000);
            string result = "/Upload/" + file.FileName;
            return result;
        }

        // POST: Admin/News/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(NEW collection)
        {
            try
            {
                // TODO: Add insert logic here
                data.NEWs.InsertOnSubmit(collection);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Admin/News/Edit/5
        [ValidateInput(false)]
        public ActionResult Edit(int id)
        {
            var n = data.NEWs.Single(s => s.ID == id);
            return View(n);
        }

        // POST: Admin/News/Edit/5
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int id, NEW collection)
        {
            try
            {
                // TODO: Add update logic here
                NEW n = data.NEWs.Single(s => s.ID == id);
                n.TieuDe = collection.TieuDe;
                n.LinkAnh = collection.LinkAnh;
                n.NoiDung = collection.NoiDung;
                n.NgayTao = collection.NgayTao;
                n.NguoiTao = collection.NguoiTao;
                n.ViewCount = collection.ViewCount;
                n.MaLSP = collection.MaLSP;
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/News/Delete/5
        public ActionResult Delete(int id)
        {
            var n = data.NEWs.Single(s => s.ID == id);
            return View(n);
        }

        // POST: Admin/News/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var nDel = data.NEWs.Single(s => s.ID == id);
                data.NEWs.DeleteOnSubmit(nDel);
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
