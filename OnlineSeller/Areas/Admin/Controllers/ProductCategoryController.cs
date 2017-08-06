using System.Web.Mvc;
using Model.Data;
using Model.EF;

namespace OnlineSeller.Areas.Admin.Controllers
{
    public class ProductCategoryController : BaseController
    {
        // GET: Admin/ProductCategory
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductCat productCat)
        {
            return View();
        }


        [HttpPost]
        public JsonResult GetChildListById(string selectedValue)
        {
            if (selectedValue != "")
            {
                var selectval = int.Parse(selectedValue);
                var cateList = new ProductCategoryData().ListChildById(selectval);
                return Json(data: new
                {
                    CateList = cateList,JsonRequestBehavior.AllowGet
                });
            }
            else
            {
                return Json(data: null);
            }
        }
        public void SetviewBag(long? selectedId = null)
        {
            var data = new ProductCategoryData();
            ViewBag.CatID = new SelectList(data.ListAllForAdmin(), "ID", "Name", selectedId);
        }
    }
}