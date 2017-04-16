using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COP_4710_College_App.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult LoginPage()
        {
            Session["loggedIn"] = true;
            Session["privilegeID"] = 2;

            if (Models.SessionHandler.loggedIn())
                return RedirectToAction("HomePage");
            else
            {
                Session["loggedIn"] = false;
                return View();
            }
        }

        [HttpPost]
        public ActionResult LoginPage(string email, string password)
        {
            if (Models.SessionHandler.tryLogin(email, password))
            {
                Session["loggedIn"] = true;
                Session["privilegeID"] = 2;
                return RedirectToAction("HomePage");
            }
            return View();
        }

        [HttpGet]
        public ActionResult HomePage()
        {
            if(Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage");
            }

            ViewBag.schools = Models.SchoolData.viewSchools();
            Session["numSchools"] = ViewBag.schools.Count;
            //get number of schools
            //get number of events
            //get number of modified events?
            //get number of members
            //get most recent 8 members



            return View();
        }

        [HttpGet]
        public ActionResult SignupPage()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SignupPage(string email, string firstname, string lastname, string password)
        {
            //Validate
            return RedirectToAction("HomePage");
        }


    }
}