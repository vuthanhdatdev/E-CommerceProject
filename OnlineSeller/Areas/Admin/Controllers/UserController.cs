using System;
using System.Web.Mvc;
using Model.Data;
using Model.EF;
using OnlineSeller.Common;
using CommonConstants = OnlineSeller.Common.CommonConstants;
using Encryptor = OnlineSeller.Common.Encryptor;

namespace OnlineSeller.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Index(string searchString, int page = 1,int pagesize =10)
        {
            var data = new UserData();
            var model = data.ListPaging(searchString, page, pagesize);
            ViewBag.searchString = searchString;
            return View(model);
        }

        
        [HttpGet]
        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(int id)
        {
            var usr = new UserData().GetById(id);
            return View(usr);
        }
        
        [HttpGet]
        [HasCredential(RoleID = "CREATE_USER")]
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [HasCredential(RoleID = "CREATE_USER")]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var data = new UserData();
                var md5Encryptedpwd = Encryptor.Md5Hash(user.Password);
                user.Password = md5Encryptedpwd;
                user.CreatedDate = DateTime.Now;
                var id = data.Insert(user);
                if (id > 0)
                {
                    SetAlert("Add User Success", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    SetAlert("Add User Failed", "error");
                    ModelState.AddModelError("", "Cannot Add user");
                }
            }

            return View("Create");
        }

        
        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(User user)
        {
            if (!ModelState.IsValid) return View("Index");
            var data = new UserData();
            if (!string.IsNullOrEmpty(user.Password))
            {
                var md5Encryptedpwd = Encryptor.Md5Hash(user.Password);
                user.Password = md5Encryptedpwd;
            }

            var id = data.UpdateUser(user);
            if (id)
            {
                SetAlert("Update User Success", "success");
                return RedirectToAction("Index", "User");
            }
            ModelState.AddModelError("", "Cannot Edit user");

            return View("Index");
        }

        
        [HttpDelete]
        [HasCredential(RoleID = "DELETE_USER")]
        public ActionResult Delete(int id)
        {

            new UserData().DeleteUser(id);
            SetAlert("Delete User Success", "success");
            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserData().ChangeStatus(id);
            return Json(data: new
            {
                status = result
            });
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }
    }
}