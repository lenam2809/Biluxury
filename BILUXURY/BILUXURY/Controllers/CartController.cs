using BILUXURY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Windows.Documents;

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
            var tongtien = 0;

            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            foreach (var thanhtien in list)
            {
                tongtien += (int)thanhtien.SanPham.Gia * thanhtien.SoLuong;
            }
            ViewBag.tongtien = tongtien;
            return View(list);
        }


        [HttpPost]
        public JsonResult UpDate(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsItem = jsonCart.SingleOrDefault(x => x.SanPham.MaSP == item.SanPham.MaSP);
                if (jsItem != null)
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
                }
                else
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

    public ActionResult MuaNgay(int masp, int soluong)
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
            }
            else
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

        return RedirectToAction("ThanhToan");
    }

    public ActionResult ThanhToan()
    {
        var cart = Session[CartSession];
        var list = new List<CartItem>();

        if (cart != null)
        {
            list = (List<CartItem>)cart;
        }
        if (User.Identity.IsAuthenticated)
        {
            string emailkh = HttpContext.User.Identity.Name;
            var kh = data.KHACHHANGs.FirstOrDefault(k => k.Email == emailkh);
            ViewBag.tenkh = kh.TenKH;
            ViewBag.diachi = kh.DiaChi;
            ViewBag.email = emailkh;
            ViewBag.phone = kh.Phone;
        }

        return View(list);
    }

    [HttpPost]
    public async Task<ActionResult> ThanhToan(string TenKH, string DiaChi, string Email, string Phone, CartItem item)
    {
        try
        {
            if (User.Identity.IsAuthenticated)
            {
                var kh = data.KHACHHANGs.FirstOrDefault(k => k.Email == Email);
                DONHANG dh = new DONHANG();
                dh.MaKH = kh.MaKH;
                dh.NgayDH = DateTime.Now;
                dh.MaShipper = 1;
                dh.IsActive = false;
                data.DONHANGs.InsertOnSubmit(dh);
                data.SubmitChanges();


                await Task.Delay(1000);
                var cart = (List<CartItem>)Session[CartSession];
                for (int i = 0; i < cart.Count; i++)
                {
                    CHITIETDONHANG ctdh = new CHITIETDONHANG();
                    ctdh.MaDH = dh.MaDH;
                    ctdh.MaSP = cart[i].SanPham.MaSP;
                    ctdh.SoLuong = cart[i].SoLuong;
                    ctdh.GhiChu = "nothing";
                    data.CHITIETDONHANGs.InsertOnSubmit(ctdh);
                }
                data.SubmitChanges();
                Session.Remove("CartSession");
            }
            else
            {
                KHACHHANG kh = new KHACHHANG();
                kh.TenKH = TenKH.Trim();
                kh.DiaChi = DiaChi.Trim();
                kh.Email = Email.Trim();
                kh.Phone = Phone.Trim();
                data.KHACHHANGs.InsertOnSubmit(kh);
                data.SubmitChanges();

                DONHANG dh = new DONHANG();
                dh.MaKH = kh.MaKH;
                dh.NgayDH = DateTime.Now;
                dh.MaShipper = 1;
                dh.IsActive = false;
                data.DONHANGs.InsertOnSubmit(dh);
                data.SubmitChanges();


                await Task.Delay(500);
                var cart = (List<CartItem>)Session[CartSession];
                for (int i = 0; i < cart.Count; i++)
                {
                    CHITIETDONHANG ctdh = new CHITIETDONHANG();
                    ctdh.MaDH = dh.MaDH;
                    ctdh.MaSP = cart[i].SanPham.MaSP;
                    ctdh.SoLuong = cart[i].SanPham.SoLuong;
                    ctdh.GhiChu = "nothing";
                    data.CHITIETDONHANGs.InsertOnSubmit(ctdh);
                }
                data.SubmitChanges();
                Session.Remove("CartSession");
            }
            return RedirectToAction("Index");
        }
        catch
        {
            return RedirectToAction("Register", "Home");
        }
    }
}
}