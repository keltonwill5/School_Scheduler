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
            ViewBag.users = Models.MembersData.viewMembers();
            Session["numMembers"] = ViewBag.users.Count;
            ViewBag.schools = Models.SchoolData.viewSchools();
            Session["numSchools"] = ViewBag.schools.Count;
            ViewBag.schoolNames = new List<string>();
            foreach(var item in ViewBag.schools)
            {
                ViewBag.schoolNames.Add(item.name);
            }



            return View();
        }

        public ActionResult DeleteUser(string DeleteUserBtn)
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            if (Models.SessionHandler.userAllowed(2) == false)
            {
                return RedirectToAction("HomePage", "Home");
            }




            Models.MembersData.deleteMember(int.Parse(DeleteUserBtn));

            return RedirectToAction("ViewUsers");
        }

        }
}