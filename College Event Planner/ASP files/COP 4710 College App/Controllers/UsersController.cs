using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COP_4710_College_App.Controllers
{
    public class UsersController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult ViewUsers()
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage","Home");
            }
            //ViewBag.users = something when i get code
            //get school names
            ViewBag.users = new List<Models.MembersViewModel>();
            ViewBag.schoolNames = new List<string>()
            {
                "yes",
                "no",
                "kill me",
                "Why am I up right now"
            };
            for (int i = 1; i < 10; i++)
            {
                Models.MembersViewModel temp = new Models.MembersViewModel();
                temp.id = i;
                temp.firstName = "" + i;
                temp.lastName = "" + i;
                temp.picture = "" + i;
                temp.createDate = DateTime.Today;
                temp.createTime = DateTime.Now;
                temp.email = "" + i;
                temp.password = "" + i;
                temp.schoolNameId = i%2+2;
                temp.userTypeId = 1;

                ViewBag.users.Add(temp);
            }



            return View();
        }
    }
}