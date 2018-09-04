using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValueObject;

namespace MyShop.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Home
        public ActionResult Login()
        {
            return View(new Models_Controllers.UserModel().getElements());
        }

        public ActionResult LoginDetails(int id)
        {
            return View(new Models_Controllers.UserModel().getElementById(id));
        }

        [HttpPost]
        public ActionResult LoginDetails(User obj)
        {
            new Models_Controllers.UserModel().update(obj);
            return RedirectToAction("Login");
        }

        public ActionResult LoginCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginCreate(User obj)
        {
            new Models_Controllers.UserModel().create(obj);
            return RedirectToAction("Login");
        }

        public JsonResult LoginDelete(int id)
        {
            return Json(new Models_Controllers.UserModel().delete(id));
        }

        [HttpGet]
        public ActionResult LoginSearch(string username, int currentPage=1)
        {
            ViewBag.maxPage = new Models_Controllers.UserModel().maxPage(username, CommonConstants.PAGESIZE);
            ViewBag.query = username;
            return View(new Models_Controllers.UserModel().searchpageList(username, CommonConstants.PAGESIZE, currentPage));
        }
    }
}