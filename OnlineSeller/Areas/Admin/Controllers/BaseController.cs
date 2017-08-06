using System.Web.Mvc;
using System.Web.Routing;
using OnlineSeller.Common;

namespace OnlineSeller.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result =new RedirectToRouteResult(new RouteValueDictionary(new {controller = "Login", action = "Index",Area = "Admin"}));
            }
            base.OnActionExecuting(filterContext);
        }

        protected void SetAlert(string alert,string type)
        {
            TempData["AlertMessage"] = alert;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}