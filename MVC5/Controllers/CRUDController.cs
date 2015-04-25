using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5.Models;
using System.Data.Entity.Validation;

namespace MVC5.Controllers
{
    public class CRUDController : BaseController
    {
        //FabricsEntities db = new FabricsEntities();
        
        // GET: CRUD
        public ActionResult Index(string keywords, int limit = 10)
        {
            //var data = db.Product.Where(p => p.ProductName.StartsWith(keywords)).Take(limit);

            //var data = db.Database.SqlQuery<Product>("SELECT TOP " + limit + " * FROM dbo.Product WHERE ProductName like @p0", keywords + "%").AsQueryable();

            var data = db.GetProducts();
            
            ViewBag.keywords = keywords;

            return View(data);
        }

        // GET: CRUD/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRUD/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Product product = new Product();
                product.ProductName = collection["ProductName"];
                product.Price = Convert.ToDecimal(collection["Price"]);
                product.Stock = Convert.ToDecimal(collection["Stock"]);
                product.Active = true;

                db.Product.Add(product);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult BatchUpdate()
        {
            var data = db.Product.Where(p => p.ProductName.StartsWith("C"));

            foreach (var item in data)
            {
                item.Price = item.Price * 2;
            }
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                
                throw ex;
            }
            
            return RedirectToAction("Index");
        }

        // GET: CRUD/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CRUD/Edit/5
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

        // GET: CRUD/Delete/5
        public ActionResult Delete(int id)
        {
            var client = db.Client.Find(id);

            foreach (var order in client.Order.ToList())
	        {
                db.OrderLine.RemoveRange(order.OrderLine);

	        }

            db.Order.RemoveRange(client.Order.ToList());
          
            db.Client.Remove(client);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: CRUD/Delete/5
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
