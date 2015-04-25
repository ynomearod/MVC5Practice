using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View1()
        {
            return View("View2");
        }

        public ActionResult View2()
        {
            return PartialView();
        }

        public ActionResult ContentView()
        {
            return Content("<svcType>Balinq</svcType>", "text/xml");
        }
    }
}