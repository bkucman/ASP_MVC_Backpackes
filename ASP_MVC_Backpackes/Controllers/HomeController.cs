using ASP_MVC_Backpackes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_MVC_Backpackes.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public ActionResult ListOfUsers()
        {
            var role = (from r in context.Roles where r.Name.Contains("Gosc") select r).FirstOrDefault();
            var users = context.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)).ToList();

            var userVM = users.Select(user => new UserViewModel
            {
                Email = user.Email,
                RoleName = "Gosc"
            }).ToList();


            var role2 = (from r in context.Roles where r.Name.Contains("Admin") select r).FirstOrDefault();
            var admins = context.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role2.Id)).ToList();

            var adminVM = admins.Select(user => new UserViewModel
            {
                Email = user.Email,
                RoleName = "Admin"
            }).ToList();


            var model = new GroupedUserViewModel { Users = userVM, Admins = adminVM };
            return View("_ListOfUsers",model);

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Info o apce";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Dane kontkatowe itd.";

            return View();
        }
    }
}