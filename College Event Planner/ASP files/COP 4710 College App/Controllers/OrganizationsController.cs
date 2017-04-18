using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COP_4710_College_App.Controllers
{
    public class OrganizationsController : Controller
    {
        [HttpGet]
        public ActionResult ViewOrganizations()
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            ViewBag.rsos = Models.RsoData.viewRSO();
            return View();
        }

        public ActionResult DeleteRSO(string DeleteBtn)
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            if (Models.SessionHandler.userAllowed(2) == false)
            {
                return RedirectToAction("HomePage", "Home");
            }

            Models.RsoData.deleteRSO(int.Parse(DeleteBtn));


            return RedirectToAction("ViewOrganizations");
        }

        [HttpGet]
        public ActionResult AddOrganizations()
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            if (Models.SessionHandler.userAllowed(1) == false)
            {
                return RedirectToAction("HomePage", "Home");
            }
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddOrganizations(string Name, string SchoolName, string Type, string ContactName, string ContactPhone, string ContactEmail, string Desc)
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            if (Models.SessionHandler.userAllowed(2) == false)
            {
                return RedirectToAction("HomePage", "Home");
            }

            Models.RsoData.addRSO(Name, SchoolName, Type, ContactName, ContactPhone, ContactEmail, Desc, 4);
            return View();
        }

        public ActionResult JoinRSO(string JoinBtn)
        {

            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            if (Models.SessionHandler.userAllowed(2) == false)
            {
                return RedirectToAction("HomePage", "Home");
            }

            Models.RsoData.joinRSO(int.Parse(JoinBtn), 7);


            return RedirectToAction("ViewOrganizations");

        }

        public ActionResult UpdateRSO(string Name, string SchoolName, string Type, string ContactName, string ContactPhone, string ContactEmail, string Description)
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            if (Models.SessionHandler.userAllowed(2) == false)
            {
                return RedirectToAction("HomePage", "Home");
            }

            Models.RsoData.modifyRSO(6, Name, SchoolName, Type, ContactName, ContactPhone, ContactEmail, Description, 4);



            return RedirectToAction("ViewOrganizations");
        }
    }
}