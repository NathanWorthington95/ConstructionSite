﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        public ActionResult Design()
        {
            ViewBag.Message = "Design";

            return View();
        }

        public ActionResult CaseStudies()
        {
            ViewBag.Message = "Case Studies";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page";

            return View();
        }

        public ActionResult Welcome()
        {

            return View();
        }

        public ActionResult Logout()
        {

            return View();
        }
    }
}