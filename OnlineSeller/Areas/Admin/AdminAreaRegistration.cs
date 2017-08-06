using System.Web.Mvc;

namespace OnlineSeller.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin Logout",
                "Admin/logout",
                new { Controller = "Login", action = "Logout", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineSeller.Areas.Admin.Controllers" }
            );
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { Controller="Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineSeller.Areas.Admin.Controllers" }
            );

        }
    }
}