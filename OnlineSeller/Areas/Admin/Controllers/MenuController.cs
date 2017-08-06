using System.Web.Mvc;
using Model.Data;
using Model.EF;

namespace OnlineSeller.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        // GET: Admin/Menu
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(Menu menu)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(long id)
        {
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new MenuData().ChangeStatus(id);
            return Json(new{
                status = result
            });
        }
    }
}