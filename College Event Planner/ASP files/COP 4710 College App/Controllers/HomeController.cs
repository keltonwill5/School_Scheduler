﻿using System;
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
           Models.callData dataPull = new Models.callData();
            
            IEnumerable<Models.TestModel> tests = dataPull.DataPull();
            ViewBag.MyTests = tests;
            return View();
        }

        public ActionResult HomePage()
        {
            return View();
        }
    }
}