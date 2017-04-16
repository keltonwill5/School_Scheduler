using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COP_4710_College_App.Controllers
{
   



    public class SchoolsController : Controller
    {
        [HttpGet]
        public ActionResult ViewSchools()
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            ViewBag.schools = Models.SchoolData.viewSchools();
            Session["numSchools"] = ViewBag.schools.Count;


            return View();
        }

        [HttpGet]
        public ActionResult AddSchools()
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage", "Home");
            }



            return View();
        }

        [HttpPost]
        public ActionResult AddSchools(string schoolname, string address, string phonenumber, string schoolemail)
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage", "Home");
            }
            Models.SchoolData.addSchool(schoolname, address, phonenumber, schoolemail);
            return View();
        }


        public ActionResult UpdateSchool(string SchoolName, string SchoolAddress, string SchoolEmail, string SchoolPhone)
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage", "Home");
            }

            Models.SchoolData.modifySchool((int)Session["MODIFYID"], SchoolName, SchoolAddress, SchoolPhone, SchoolEmail);



            return RedirectToAction("ViewSchools");
        }

        public ActionResult DeleteSchool(string DeleteBtn)
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage", "Home");
            }


            Models.SchoolData.deleteSchool(int.Parse(DeleteBtn));


            return RedirectToAction("ViewSchools");
        }
/*
        public Action setModifyID(string ModifyBtn)
        {
            Session["MODIFYID"] = int.Parse(ModifyBtn);
        }
        */
    }
}