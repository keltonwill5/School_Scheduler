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
                return RedirectToAction("LoginPage", "Home");
            }
            ViewBag.rso = Models.RsoData.viewRSO();
            Session["numOrg"] = ViewBag.rso.Count;

            return View();
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

            ViewBag.schools = Models.SchoolData.viewSchools();

            return View();
        }

        [HttpPost]
        public ActionResult AddOrganizations(string SchoolName, string GroupName, string GroupType, string Desc, string ContactName, string NumMem, string Mem1, string Mem2, string Mem3, string Mem4, string Mem5, string Mem6, string Mem7, string Mem8, string Mem9, string Mem10, string orgPhone, string orgEmail)
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            if (Models.SessionHandler.userAllowed(1) == false)
            {
                return RedirectToAction("HomePage", "Home");
            }

            Models.RsoData.addRSO(GroupName, SchoolName, GroupType, ContactName, orgPhone, orgEmail, Desc, int.Parse(NumMem));

            return RedirectToAction("ViewOrganizations");
        }


        public ActionResult DeleteRSO(string deleteRSO)
        {

            Models.RsoData.deleteRSO(int.Parse(deleteRSO));
            return RedirectToAction("ViewOrganizations");



        }
    }
}