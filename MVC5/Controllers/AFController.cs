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
        [HandleError(Master = "", ExceptionType = typeof(ArgumentException), View = ("Error.A"))]
        public ActionResult ShowMeError(string type)
        {
            if (type == "1")
            {
                throw new ArgumentException("XXX");
            }
            throw new Exception("error");
            return View();
        }
    }
}