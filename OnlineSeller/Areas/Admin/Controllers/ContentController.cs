using System.Web.Mvc;
using Model.Data;
using Model.EF;

namespace OnlineSeller.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetviewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Content model)
        {
            if (ModelState.IsValid)
            {
                var data = new ContentData();
                var id = data.InsertContent(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    ModelState.AddModelError("", "Cannot add content");
                }
            }
            SetviewBag();
            return View();
        }
        public void SetviewBag(long? selectedId = null)
        {
            var data = new CategoryData();
            ViewBag.CategoryID = new SelectList(data.ListAll(),"ID","Name", selectedId);
        }
    }
}