﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    public class ViewController : Controller
    {
        // GET: View
        public ActionResult Index()
        {
            int[] a = new int[] { 1, 2, 3, 4, 5 };
            ViewBag.a = a;
            return PartialView();
        }
    }
}