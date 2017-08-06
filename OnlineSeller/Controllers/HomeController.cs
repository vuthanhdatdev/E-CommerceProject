using System.Collections.Generic;
using System.Web.Mvc;
using Model.Data;
using OnlineSeller.Common;
using OnlineSeller.Models;

namespace OnlineSeller.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var product = new ProductData();
            ViewBag.NewProducts = product.ListNewProduct(4);
            ViewBag.ListFeatureProducts = product.ListFeatureProduct(4);
            return View();
        }

        [ChildActionOnly]
        public ActionResult _TopMenu()
        {
            var model = new MenuData().ListByGroupId(2);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult _MainMenu()
        {
            var model = new MenuData().ListByGroupId(1);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Menu_Left()
        {
            var model = new ProductCategoryData().ListAll();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult _Footer()
        {
            var model = new FooterData().GetFooter();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Slide()
        {
            var model = new SlideData().GetSlides();
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult _Cart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>) cart;
            }
            return PartialView(list);
        }
    }
}