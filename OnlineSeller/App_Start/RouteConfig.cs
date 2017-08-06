using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineSeller
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });
            routes.MapRoute(
                name: "Login User",
                url: "login",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineSeller.Controllers" }
            );
            routes.MapRoute(
                name: "Cart",
                url: "cart",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineSeller.Controllers" }
            );
           routes.MapRoute(
                name: "Payment",
                url: "payment",
                defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineSeller.Controllers" }
            );

            routes.MapRoute(
                name: "Update Cart",
                url: "cart-update",
                defaults: new { controller = "Cart", action = "Update", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineSeller.Controllers" }
            );
            routes.MapRoute(
                name: "Add to Cart",
                url: "add-to-cart",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineSeller.Controllers" }
            );
            routes.MapRoute(
                name: "Product Details",
                url: "detail/{metaTitle}-{id}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineSeller.Controllers" }
            );

            routes.MapRoute(
                name: "Product Category",
                url: "product-cat/{metaTitle}-{id}",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineSeller.Controllers" }
            );

            routes.MapRoute(
                name: "About Us",
                url: "about-us",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineSeller.Controllers" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new [] { "OnlineSeller.Controllers" }
            );
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }


}
