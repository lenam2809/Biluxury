using System.Web.Mvc;
using System.Web.Routing;

namespace BILUXURY
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "gio-hang",
                url: "Cart/AddItem/{masp}/{soluong}",
                defaults: new { controller = "Cart", action = "AddItem", masp = UrlParameter.Optional , soluong = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            

        }
    }
}
