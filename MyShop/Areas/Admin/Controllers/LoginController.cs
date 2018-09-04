using Models_Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ValueObject;

namespace MyShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Home(string Username, string Password)
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel().checkLogin(Username, Password);
                if (user != null)
                {
                    //Session
                    Session.Add("SESSION_USER", user);

                    //Cookie
                    FormsAuthentication.SetAuthCookie(user.UserName, true);
                    return RedirectToAction("Login", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Login error!");
                }
            }

            return View();
        }
    }
}