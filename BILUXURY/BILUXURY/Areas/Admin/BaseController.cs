using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BILUXURY.Areas.Admin
{
    public class BaseController : Controller
    {

        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    var sess = ()Session[CommonConstants.EMPLOYEE_SESSION];
        //    if (sess == null)
        //    {
        //        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "HomeAdmin", action = "Login", Area = "Admin" }));
        //    }
        //    base.OnActionExecuting(filterContext);
        //}
    }
}