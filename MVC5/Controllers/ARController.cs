using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    public class ARController : BaseController
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View1()
        {
            return View("View1");
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

        public ActionResult Json1()
        {
            db.Configuration.LazyLoadingEnabled = false;
            var data = db.Product.Take(10);
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        public ActionResult redirect1()
        {
            //return Redirect("/AR/Json1");
            //return RedirectToAction("file3", new { url = "https://t.kfs.io/upload_images/31696/miniASP_final_LOGO_cs4-02_promote.jpg" });
            return RedirectToActionPermanent("file3", new { url = "https://t.kfs.io/upload_images/31696/miniASP_final_LOGO_cs4-02_promote.jpg" });            
        }

        public ActionResult httpstatus()
        {
            return HttpNotFound();
        }
    }
}