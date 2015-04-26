using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public ActionResult file1()
        {
            byte[] content = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/file3.png"));
            return File(content, "image/png");
        }

        public ActionResult file2()
        {
            return File(Server.MapPath("~/Content/banner3_large.jpg"),"image/jpeg");
        }

        public ActionResult file3(string url)
        {
            var wc = new WebClient();
            var content = wc.DownloadData(url);
            return File(content, "image/png");
        }

        public ActionResult file4()
        {
             byte[] content = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/banner3_large.jpg"));
            return File(content, "image/jpeg", "LINQ");
        }
    }
}