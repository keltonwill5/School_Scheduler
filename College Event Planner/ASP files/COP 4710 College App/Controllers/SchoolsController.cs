﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COP_4710_College_App.Controllers
{
    public class SchoolsController : Controller
    {
        public ActionResult ViewSchools()
        {
            Models.SchoolData.addSchool("Change", "Change", "Change", "Change");


            return View();
        }

        public ActionResult AddSchools()
        {

            return View();
        }

    }
}