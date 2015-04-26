using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    public class AFController : Controller
    {
        // GET: AF
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowMeError()
        {
            throw new Exception("error");
            return View();
        }
    }
}