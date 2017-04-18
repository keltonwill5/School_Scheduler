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

            Session["name"] = "David Clapp";
            Session["schoolID"] = 1;
            Session["privilege"] = "Supreme Overlord";
            Session["privilegeID"] = 9001;
            Session["createdDate"] = "00/00/00";
            return RedirectToAction("HomePage");


            









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
            if (Models.MembersData.loginMember(email,password))
            {
                Models.MembersViewModel cur_user = Models.MembersData.getMember(email);
                Session["loggedIn"] = true;

                Session["name"] = cur_user.firstName + cur_user.lastName;
                Session["curID"] = cur_user.id;
                Session["schoolID"] = cur_user.schoolNameId;
                Session["privilege"] = Models.MembersData.getTitle(cur_user.userTypeId);
                Session["privilegeID"] = 2; // cur_user.userTypeId;
                Session["createdDate"] = cur_user.createDate.ToString("MM/dd/yyyy");
                return RedirectToAction("HomePage");
            }
            return View();
        }

        [HttpGet]
        public ActionResult HomePage()
        {
            if(!Models.SessionHandler.loggedIn())
            {
                return RedirectToAction("LoginPage");
            }

            ViewBag.schools = Models.SchoolData.viewSchools();
            Session["numSchools"] = ViewBag.schools.Count;

            ViewBag.users = Models.MembersData.viewMembers();
            Session["numMembers"] = ViewBag.users.Count;

            ViewBag.events = Models.EventsData.viewEvents();
            Session["numEvents"] = ViewBag.events.Count;

            ViewBag.rso = Models.RsoData.viewRSO();
            Session["numOrg"] = ViewBag.rso.Count;

            return View();
        }


        public ActionResult logOut()
        {
            Session["loggedIn"] = false;

            Session["name"] = null;
            Session["schoolID"] = null;
            Session["privilege"] = null;
            Session["privilegeID"] = null;
            Session["createdDate"] = null;
            return RedirectToAction("LoginPage");
        }


        [HttpGet]
        public ActionResult SignupPage()
        {
            ViewBag.schools = Models.SchoolData.viewSchools();
            
            return View();
        }

        [HttpPost]
        public ActionResult SignupPage(string email, string firstname, string lastname, string password, string schoolOP)
        {
            if (Models.MembersData.checkExist(email))
                return View();
            else
            {
                Models.MembersData.addMember(firstname, lastname, "../Images/stickman.jpg", email, password,schoolOP,"0");

                Models.MembersViewModel cur_user = Models.MembersData.getMember(email);
                Session["loggedIn"] = true;

                Session["name"] = cur_user.firstName + cur_user.lastName;
                Session["schoolID"] = cur_user.schoolNameId;
                Session["privilege"] = Models.MembersData.getTitle(cur_user.userTypeId);
                Session["privilegeID"] = cur_user.userTypeId;
                Session["createdDate"] = cur_user.createDate.ToString("MM/dd/yyyy");

                return RedirectToAction("HomePage");
            }
        }


    }
}