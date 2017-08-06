using System;
using System.Web.Mvc;
using Model.Data;


namespace OnlineSeller.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var db = new ProductData();
            var model = db.ListNewProduct(1);
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult Menu_Left()
        {
            var model = new ProductCategoryData().ListAll();
            return PartialView(model);
        }

        public ActionResult Category(long id,int page = 1,int pageSize = 5)
        {
            ViewBag.Category = new ProductCategoryData().ViewDetail(id);
            //int totalRecord = 0;
            var model = new ProductData().ListByCateId(id,page, pageSize);
            // Pagination
            //ViewBag.Total = totalRecord;
            //ViewBag.Page = page;
            //int maxPage = 5;

            //var totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            //ViewBag.TotalPage = totalPage;
            //ViewBag.MaxPage = maxPage;
            //ViewBag.First = 1;
            //ViewBag.Last = maxPage;
            //ViewBag.Next = page + 1;
            //ViewBag.Prev = page - 1;
            return View(model);
        }

        public ActionResult Detail(long id)
        {
            var product = new ProductData().Detail(id);
            if (product.CatID != null) ViewBag.Category = new ProductCategoryData().ViewDetail(product.CatID.Value);
            ViewBag.RelatedProducts = new ProductData().ListRelatedProducts(id);
            return View(product);
        }
    }
}