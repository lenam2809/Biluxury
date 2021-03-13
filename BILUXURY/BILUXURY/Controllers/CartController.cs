using BILUXURY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Mvc;

namespace BILUXURY.Controllers
{
    public class CartController : Controller
    {

        private const string CartSession = "CartSession";
        DataClasses1DataContext data = new DataClasses1DataContext();

        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();

            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return View(list);
        }
      

        [HttpPost]
        public JsonResult UpDate(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach(var item in sessionCart)
            {
                var jsItem = jsonCart.SingleOrDefault(x => x.SanPham.MaSP == item.SanPham.MaSP);
                if(jsItem != null)
                {
                    item.SoLuong = jsItem.SoLuong;
                }
            }
            Session[CartSession] = sessionCart;

            return Json(new
            {
                Status = true
            });
        }

        [HttpPost]
        public JsonResult Delete(long masp)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.SanPham.MaSP == masp);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                Status = true
            });
        }


        [HttpPost]
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                Status = true
            });
        }

        public ActionResult AddItem(int masp, int soluong)
        {
            var sanphams = data.SANPHAMs.FirstOrDefault(s => s.MaSP == masp);
            var cart = Session[CartSession];
            if (cart != null)
            {

                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.SanPham.MaSP == masp))
                {
                    foreach (var item in list)
                    {
                        if (item.SanPham.MaSP == masp)
                        {
                            item.SoLuong += soluong;
                        }
                    }
                } else
                {
                    var item = new CartItem();
                    item.SanPham = sanphams;
                    item.SoLuong = soluong;
                    list.Add(item);

                    //gan vao session
                    Session[CartSession] = list;
                }

            }
            else
            {
                //tao moi cart
                var item = new CartItem();
                item.SanPham = sanphams;
                item.SoLuong = soluong;
                var list = new List<CartItem>();
                list.Add(item);
                //gan vao session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
    }
}