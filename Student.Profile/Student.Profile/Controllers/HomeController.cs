using Student.Profile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student.Profile.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [Authorize]
        public ActionResult Protected()
        {
            var user = (UserIdentity)User.Identity;
            return View((object)user.UserId);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View();
        }
        [Authorize(Roles = "Company")]
        public ActionResult Company()
        {
            return View();
        }

        [Authorize]
        public ActionResult AdminOrCompany()
        {
            if (!User.IsInRole("Admin") && !User.IsInRole("Company"))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

         [Authorize(Roles = "Admin, User")]
        public ActionResult AdminOrUser()
        {
            return View();
        }

         [Authorize(Users = "kripesh,testuser")]
        public ActionResult SelectedUsersOnly()
        {
            return View();
        }
    }
}
