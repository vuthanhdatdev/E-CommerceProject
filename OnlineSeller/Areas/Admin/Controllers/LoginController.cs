using System.Web.Mvc;
using OnlineSeller.Areas.Admin.Models;
using Model.Data;
using OnlineSeller.Common;

namespace OnlineSeller.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("Index");
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var data = new UserData();
                var result = data.Login(model.username, Encryptor.Md5Hash(model.password),true);
                if (result == 1)
                {
                    var user = data.GetBy_UserName(model.username);
                    var usersession = new UserLogin
                    {
                        userName = user.UserName,
                        userID = user.ID,
                        GroupID = user.GroupID
                    };
                    var listCredentials = data.GetListCredential(model.username);
                    Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredentials);
                    Session.Add(CommonConstants.USER_SESSION,usersession);
                    return RedirectToAction("Index","Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Username is unavailable ");
                }
                else if (result == 2)
                {
                    ModelState.AddModelError("", "Wrong Password ");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Username is Temporarily Unavailable ");
                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "You have no Permission to login");
                }
                else
                {
                    ModelState.AddModelError("", "Login Failed!");
                }
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }
    }
}