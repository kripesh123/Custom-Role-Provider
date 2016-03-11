using Student.Profile.Context;
using Student.Profile.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student.Profile.Controllers
{
    public class ManageController : Controller
    {
        private  AppDbContext _context;

        public ManageController()
        {
            _context = new AppDbContext();
        }

        // GET: Manage
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(_context.Users.Where(u=> u.UserId>1).ToList());
        }

       [Authorize(Roles = "Admin")]
        public JsonResult UpdateRole(int userId, int roleId)
        {
            _context.AddUserRole(new UserRole { UserId = userId, RoleId = roleId });
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }

    public static class ListProvider
    {
        public static List<SelectListItem> Roles = new List<SelectListItem>
                                                   {
                                                       new SelectListItem { Text = "Admin", Value = "1" },
                                                       new SelectListItem { Text = "User", Value = "2" },
                                                       new SelectListItem { Text = "Company", Value = "3" }
                                                   };
        public static List<SelectListItem> GetRoles(int roleId)
        {
            Roles.ForEach(r => r.Selected = false);
            var role = Roles.Single(r => r.Value == roleId.ToString(CultureInfo.InvariantCulture));
            role.Selected = true;
            return Roles;
        }
    }
}