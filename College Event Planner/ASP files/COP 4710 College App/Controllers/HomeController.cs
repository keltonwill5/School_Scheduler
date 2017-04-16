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
           
            return View();
        }

        [HttpPost]
        public ActionResult LoginPage(FormCollection form)
        {
            foreach (string key in form.AllKeys)
            {
                Response.Write(form[key]);
            }
            return View();
        }

        public ActionResult HomePage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignupPage()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SignupPage(FormCollection form)
        {

            return View();
        }


    }
}