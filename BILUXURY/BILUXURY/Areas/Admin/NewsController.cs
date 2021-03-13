using BILUXURY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BILUXURY.Areas.Admin
{
    public class NewsController : Controller
    {

        DataClasses1DataContext data = new DataClasses1DataContext();

        // GET: Admin/News
        public ActionResult Index()
        {
            var dsnews = (from n in data.NEWs
                        select n).ToList();
            return View(dsnews);
        }

        // GET: Admin/News/Details/5
        public ActionResult Details(int id)
        {
            var n = data.NEWs.Single(s => s.NewID == id);
            return View(n);
        }

        // GET: Admin/News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/News/Create
        [HttpPost]
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
        public ActionResult Edit(int id)
        {
            var n = data.NEWs.Single(s => s.NewID == id);
            return View(n);
        }

        // POST: Admin/News/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, NEW collection)
        {
            try
            {
                // TODO: Add update logic here
                NEW n = data.NEWs.Single(s => s.NewID == id);
                n.Title = collection.Title;
                n.NewImage = collection.NewImage;
                n.Description = collection.Description;
                n.CreatedBy = collection.CreatedBy;
                n.ViewCount = collection.ViewCount;
                n.MaSP = collection.MaSP;
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
            var n = data.NEWs.Single(s => s.NewID == id);
            return View(n);
        }

        // POST: Admin/News/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var nDel = data.NEWs.Single(s => s.NewID == id);
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
