using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COP_4710_College_App.Controllers
{
    public class OrganizationsController : Controller
    {
        // GET: Home
        public ActionResult ViewOrganizations()
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage","Home");
            }
            return View();
        }

        public ActionResult AddOrganizations()
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage","Home");
            }
            return View();
        }
    }
}