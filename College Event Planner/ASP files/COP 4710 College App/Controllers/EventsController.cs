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
                return RedirectToAction("LoginPage", "Home");
            }

            List<Models.EventsViewModel> events = new List<Models.EventsViewModel>();
            events = Models.EventsData.viewEvents();

            return View(events);
        }

        [HttpGet]
        public ActionResult AddEvents()
        {

            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            if (Models.SessionHandler.userAllowed(0) == false)
            {
                return RedirectToAction("HomePage", "Home");
            }

           
            return View();
        }
       


       [HttpPost]
        public ActionResult AddEvents(string name, string type, string desc, string time, string date, string number, string address, string radius, string email)
        {

            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            if (Models.SessionHandler.userAllowed(0) == false)
            {
                return RedirectToAction("HomePage", "Home");
            }

            Models.EventsData.addEvent(name, desc, type,int.Parse(time), int.Parse(date), address, number, email, "0", (string)Session["schoolID"], "", "", "");


            return RedirectToAction("ViewEvents");
        }

        public ActionResult ModifyEvents()
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage","Home");
            }
            if (Models.SessionHandler.userAllowed(2) == false)
            {
                return RedirectToAction("HomePage", "Home");
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