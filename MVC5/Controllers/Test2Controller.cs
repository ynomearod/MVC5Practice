using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    public class Test2Controller : Controller
    {
        // GET: Test2
        public ActionResult Index()
        {
            return View();
        }

        // GET: Test2/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Test2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test2/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Test2/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Test2/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Test2/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Test2/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
