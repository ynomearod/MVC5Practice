﻿using MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    public class MBController : BaseController
    {
        // GET: MB
        public ActionResult Index()
        {
            ViewData.Model = db.Product.Find(1);
            return View();
        }

        public ActionResult tempData()
        {
           ViewData["Message1"] = "test1";
           TempData["Message2"] = "test2";

           return Redirect("/MB/tempData2");
        }

        public ActionResult tempData2()
        {
            ViewBag.Message1 = ViewData["Message1"];
            ViewBag.Message2 = TempData["Message2"];

            return View();
        }

        public ActionResult simple1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult simple1(string UserName, string Password)
        {
            return Content("simple1:" + UserName + Password);
        }

        public ActionResult simple2()
        {
            return View("simple1");
        }

        [HttpPost]
        public ActionResult simple2(FormCollection form)
        {
            return Content("simple1:" + form["UserName"] + form["Password"]);
        }

        public ActionResult Complex1()
        {
            return View("simple1");
        }

        [HttpPost]
        public ActionResult Complex1(SimpleViewModel item)
        {
            return Content("simple1:" + item.UserName + item.Password);
        }

        public ActionResult Complex2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Complex2(SimpleViewModel item1, SimpleViewModel item2)
        {
            return Content("item1:" + item1.UserName + item1.Password);
        }

        public ActionResult Complex3()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Complex3(
            [Bind(Prefix="item1")]
            SimpleViewModel item)
        {
            return Content("Complex3:" + item.UserName + item.Password);
        }

        public ActionResult Complex4()
        {
            var data = from p in db.Client
                       select new SimpleViewModel()
                       {
                           UserName = p.FirstName,
                           Password = p.LastName,
                           age = 18
                       };
            return View(data.Take(10));
        }

        [HttpPost]
        public ActionResult Complex4(IList<SimpleViewModel> item)
        {
            return Content("");
        }
        public ActionResult Complex5()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Complex5(FormCollection form)
        {
            var item = new SimpleViewModel();

            if (TryUpdateModel<SimpleViewModel>(item))
            {
                return Redirect("Complex5");
            }
            return View(item);
        }
    }
}