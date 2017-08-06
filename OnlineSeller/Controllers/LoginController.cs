using System.Web.Mvc;
using Model.Data;
using OnlineSeller.Common;
using OnlineSeller.Models;

namespace OnlineSeller.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
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
                var result = data.Login(model.username, Encryptor.Md5Hash(model.password));
                if (result == 1)
                {
                    var user = data.GetBy_UserName(model.username);
                    var usersession = new UserLogin
                    {
                        userName = user.UserName,
                        userID = user.ID
                    };
                    Session.Add(CommonConstants.USER_SESSION, usersession);
                    return RedirectToAction("Index", "Home");
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
                else
                {
                    ModelState.AddModelError("", "Login Failed!");
                }
            }
            return View("Index");
        }
    }

}