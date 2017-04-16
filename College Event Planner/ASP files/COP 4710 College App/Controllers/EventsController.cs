using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COP_4710_College_App.Controllers
{
    public class EventsController : Controller
    {   
        public ActionResult ViewEvents()
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage","Home");
            }

            return View();
        }

        public ActionResult AddEvents()
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage","Home");
            }
            return View();
        }

        public ActionResult ModifyEvents()
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage","Home");
            }
            return View();
        }

        public ActionResult JoinEvents()
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage","Home");
            }
            return View();
        }
    }
}