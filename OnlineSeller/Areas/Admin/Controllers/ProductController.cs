using System;
using System.IO;
using System.Web.Mvc;
using Model.Data;
using Model.EF;
using OnlineSeller.Common;

namespace OnlineSeller.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var product = new ProductData();
            var model = product.ProductList(searchString, page, pagesize);
            ViewBag.searchString = searchString;
            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            SetviewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var data = new ProductData();
                product.MetaTitle = Addon.FiltertoUrl(product.Name);
                product.CreatedDate = DateTime.Now;
                var childId = Request.Form["childId"];
                //Response.Write(childId);
                if (childId != null)
                {
                    product.CatID = int.Parse(childId);
                }
                var id = data.Insert(product);
                if (id > 0)
                {
                    SetAlert("Add Product Success", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Cannot Add user");
                }
            }
            SetviewBag();
            return View();
        }

        public void SetviewBag(long? selectedId = null)
        {
            var data = new ProductCategoryData();
            ViewBag.CatID = new SelectList(data.ListAllForAdmin(), "ID", "Name", selectedId);
        }

        public void SetChildList(long? selectId = null)
        {
            var data = new ProductCategoryData();
            if (selectId != null) ViewBag.ChildID = new SelectList(data.ListChild(selectId.Value), "ID", "Name",selectId);
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var model = new ProductData().GetbyId(id);
            SetviewBag(model.CatID);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (!ModelState.IsValid) return View("Index");
            var data = new ProductData();
            var result = data.Update(product);
            if (result)
            {
                SetAlert("Update Product Success", "success");
                return RedirectToAction("Index", "Product");
            }
            ModelState.AddModelError("", "Cannot Update user");
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new ProductData().Delete(id);
            SetAlert("Delete User Success", "success");
            return RedirectToAction("Index");
        }
    }
}