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
        public ActionResult LoginPage()
        {
           
            return View();
        }

        public ActionResult HomePage()
        {
            return View();
        }
    }
}