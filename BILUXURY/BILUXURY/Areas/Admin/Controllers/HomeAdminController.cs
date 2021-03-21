using BILUXURY.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace BILUXURY.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {

        DataClasses1DataContext data = new DataClasses1DataContext();
        // GET: Admin/Home
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var lsp = data.LOAISANPHAMs.ToList();
            ViewBag.lsp = lsp;

            //tính sản phẩm bán chạy nhất
            var groupSL =
                from sp in data.CHITIETDONHANGs
                group sp by sp.MaSP into spGroup
                select new
                {
                    keys = spGroup.Key,
                    sums = spGroup.Sum(x => x.SoLuong),
                };
            var test = groupSL.OrderByDescending(x => x.sums).Take(1).FirstOrDefault();
            var top1sp = data.SANPHAMs.FirstOrDefault(x => x.MaSP == (int)test.keys);
            ViewBag.masp = Convert.ToInt32(test.keys);
            ViewBag.sl = Convert.ToInt32(test.sums);
            ViewBag.link = top1sp.LinkAnh;
            ViewBag.tensp = top1sp.TenSP;


            ////Đơn hàng giá trị nhất



            //Loại sản phẩm được yêu thích nhất
            var groupLSP =
               from sp in data.SANPHAMs
               join ct in data.CHITIETDONHANGs
               on sp.MaSP equals ct.MaSP
               select new { sp.MaLoaiSP, sp.MaSP, ct.SoLuong };

            var test2 = from c in groupLSP
                        group c by c.MaLoaiSP into lspGroup
                        select new
                        {
                            keys = lspGroup.Key,
                            sums = lspGroup.Sum(x => x.SoLuong),
                        };
            var top1LSP = test2.OrderByDescending(m => m.sums).Take(1).FirstOrDefault();
            var lsptop1 = data.LOAISANPHAMs.FirstOrDefault(c => c.MaLoaiSP == top1LSP.keys);
            ViewBag.lmasp = Convert.ToInt32(top1LSP.keys);
            ViewBag.sllsp = Convert.ToInt32(top1LSP.sums);
            ViewBag.linklsp = lsptop1.Image;
            ViewBag.tenlsp = lsptop1.TenLoaiSP;


            //Khách hàng vip
            var joinkh =
               from sp in data.SANPHAMs
               join ct in data.CHITIETDONHANGs
               on sp.MaSP equals ct.MaSP
               select new { sp.MaSP, ct.SoLuong, ct.MaDH, sp.Gia, };
            var groupdh = from k in joinkh
                          group k by k.MaDH into dhGroup
                          select new
                          {
                              keys = dhGroup.Key,
                              sums = dhGroup.Sum(x => x.SoLuong * x.Gia),
                           };
            var khgroup = from d in groupdh
                          join k in data.DONHANGs
                          on d.keys equals k.MaDH
                          select new { d.keys, d.sums, k.MaKH };
            var groupkh = from k in khgroup
                          group k by k.MaKH into khGroup
                          select new
                          {
                              keys = khGroup.Key,
                              sums = khGroup.Sum(x => x.sums),
                          };
            var top1kh = groupkh.OrderByDescending(m => m.sums).Take(1).FirstOrDefault();
            var khvip = data.KHACHHANGs.FirstOrDefault(c => c.MaKH == top1kh.keys);
            ViewBag.makh = Convert.ToInt32(top1kh.keys);
            ViewBag.giatri = Convert.ToInt32(top1kh.sums);
            //ViewBag.linklsp = khvip.Image;
            ViewBag.tenkh = khvip.TenKH;




            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string user, string pass, string returnUrl)
        {
            try
            {
                var dataItems = data.TAIKHOANs.Where(x => x.Email == user
            && x.Password == pass).First();
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
                        return RedirectToAction("index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid user/pass");
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.error = "Email already exists";
                return View();
            }
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "HomeAdmin");
        }




        public ActionResult Loadding()
        {
            return View();
        }

    }
}