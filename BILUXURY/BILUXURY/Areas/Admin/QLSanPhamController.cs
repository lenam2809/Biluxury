﻿using BILUXURY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BILUXURY.Areas.Admin
{
    public class QLSanPhamController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();

        // GET: Admin/QLSanPham
        public ActionResult Index()
        {
            var dssp = (from p in data.SANPHAMs
                      select p).ToList();
            return View(dssp);
        }

        // GET: Admin/QLSanPham/Details/5
        public ActionResult Details(int id)
        {
            var sp = data.SANPHAMs.Single(s => s.MaSP == id);
            return View(sp);
        }

        // GET: Admin/QLSanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QLSanPham/Create
        [HttpPost]
        public ActionResult Create(SANPHAM collection)
        {
            try
            {
                // TODO: Add insert logic here
                data.SANPHAMs.InsertOnSubmit(collection);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/QLSanPham/Edit/5
        public ActionResult Edit(int id)
        {
            var sp = data.SANPHAMs.Single(s => s.MaSP == id);
            return View(sp);
        }

        // POST: Admin/QLSanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SANPHAM collection)
        {
            try
            {
                // TODO: Add update logic here
                SANPHAM Sp = data.SANPHAMs.Single(s => s.MaSP == id);
                Sp.TenSP = collection.TenSP;
                Sp.MaNCC = collection.MaNCC;
                Sp.MaLoaiSP = collection.MaLoaiSP;
                Sp.Gia = collection.Gia;
                Sp.ChatLieu = collection.ChatLieu;
                Sp.KieuDang = collection.KieuDang;
                Sp.XuatXu = collection.XuatXu;
                Sp.ImageLink = collection.ImageLink;
                Sp.SoLuong = collection.SoLuong;
                Sp.IsDelete = collection.IsDelete;
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/QLSanPham/Delete/5
        public ActionResult Delete(int id)
        {
            var sp = data.SANPHAMs.Single(s => s.MaSP == id);
            return View(sp);
        }

        // POST: Admin/QLSanPham/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SANPHAM collection)
        {
            try
            {
                // TODO: Add delete logic here
                var SpDel = data.SANPHAMs.Single(s => s.MaSP == id);
                data.SANPHAMs.DeleteOnSubmit(SpDel);
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
