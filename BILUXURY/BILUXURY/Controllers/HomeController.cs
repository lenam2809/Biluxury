using BILUXURY.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace BILUXURY.Controllers
{
    public class HomeController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();


        public ActionResult Index()
        {
            var lsp = (from p in data.LOAISANPHAMs
                       select p).ToList().Take(5);
            ViewBag.list = lsp;

            var sp = data.SANPHAMs.OrderByDescending(x => x.Gia).ToList().Take(4);
            ViewBag.listsp = sp;

            var sp2 = data.SANPHAMs.OrderBy(x => x.Gia).ToList().Take(4);
            ViewBag.listsp2 = sp2;

            var news = data.NEWs.OrderByDescending(x => x.ViewCount).ToList().Take(3);
            ViewBag.news = news;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string pass, string returnUrl)
        {
            try
            {
                var dataItems = data.TAIKHOANs.Where(x => x.Email == email.Trim()
            && x.Password == pass.Trim()).First();
                if (dataItems != null)
                {
                    FormsAuthentication.SetAuthCookie(dataItems.Email, false);
                    if (Url.IsLocalUrl(returnUrl)
                        && returnUrl.Length > 1
                        && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//")
                        && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid user/pass");
                    return View();
                }
            }
            catch
            {
                ViewBag.error = "Tài khoản hoặc mật khẩu không chính xác!";
                return View();
            }
            
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string name, DateTime ngaysinh, string diachi, string gioitinh, string phone, string email, string pass, string role = "member")
        {
            try
            {
                var check = data.TAIKHOANs.FirstOrDefault(s => s.Email == email);
                if (check == null)
                {
                    TAIKHOAN account = new TAIKHOAN();
                    account.Email = email;
                    account.Password = pass;
                    account.Role = role;
                    data.TAIKHOANs.InsertOnSubmit(account);

                    KHACHHANG kh = new KHACHHANG();
                    kh.TenKH = name;
                    kh.NgaySinh = ngaysinh;
                    kh.DiaChi = diachi;
                    kh.GioiTinh = gioitinh;
                    kh.Email = email;
                    kh.Phone = phone;
                    data.KHACHHANGs.InsertOnSubmit(kh);

                    data.SubmitChanges();
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    return View();
                }
                // TODO: Add insert logic here

            }
            catch
            {
                return View();
            }
        }

        public ActionResult HTCuaHang()
        {
            return View();
        }
    }
}