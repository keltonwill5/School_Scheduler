using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COP_4710_College_App.Controllers
{
    /*
    public class skool
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime createDate { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        public skool(Models.SchoolViewModel data)
        {
            id = data.id;
            name = data.name;
            createDate = data.createDate;
            address = data.address;
            phone = data.phone;
            email = data.email;
        }

        public static List<skool> skoolList(List<Models.SchoolViewModel> data)
        {
            List<skool> schools = new List<skool>();

            foreach(Models.SchoolViewModel key in data)
            {
                schools.Add(new skool(key));
            }

            return schools;
        }
    }

    */




    public class SchoolsController : Controller
    {
        [HttpGet]
        public ActionResult ViewSchools()
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage","Home");
            }
            ViewBag.schools = Models.SchoolData.viewSchools();
           

            return View();
        }

        [HttpGet]
        public ActionResult AddSchools()
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage","Home");
            }



            return View();
        }

        [HttpPost]
        public ActionResult AddSchools(string schoolname, string address, string phonenumber, string email)
        {
            if (Models.SessionHandler.loggedIn() == false)
            {
                return RedirectToAction("LoginPage","Home");
            }
            Models.SchoolData.addSchool(schoolname,address,phonenumber,email);
            return View();
        }


        public ActionResult UpdateSchool()
        {




            return View("ViewSchools");
        }

    }
}