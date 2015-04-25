﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5.Models;

namespace MVC5.Controllers
{
    public class ClientsController : Controller
    {
        //private FabricsEntities db = new FabricsEntities();
        ClientRepository repos = RepositoryHelper.GetClientRepository();

        // GET: Clients
        public ActionResult Index()
        {
            //var client = db.Client.Include(c => c.Occupation).Take(10);
            var client = repos.All();
            return View(client.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = repos.Find(id.Value);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        ClientRepository reposOccupation = RepositoryHelper.GetClientRepository();

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.OccupationId = new SelectList(reposOccupation.All(), "OccupationId", "OccupationName");
            return View();
        }

        // POST: Clients/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,FirstName,MiddleName,LastName,Gender,DateOfBirth,CreditRating,XCode,OccupationId,TelephoneNumber,Street1,Street2,City,ZipCode,Longitude,Latitude,Notes")] Client client)
        {
            if (ModelState.IsValid)
            {
                repos.Add(client);
                repos.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.OccupationId = new SelectList(reposOccupation.All(), "OccupationId", "OccupationName", client.OccupationId);
            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = repos.Find(id.Value);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.OccupationId = new SelectList(reposOccupation.All(), "OccupationId", "OccupationName", client.OccupationId);
            return View(client);
        }

        // POST: Clients/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,FirstName,MiddleName,LastName,Gender,DateOfBirth,CreditRating,XCode,OccupationId,TelephoneNumber,Street1,Street2,City,ZipCode,Longitude,Latitude,Notes")] Client client)
        {
            if (ModelState.IsValid)
            {
                repos.UnitOfWork.Context.Entry(client).State = EntityState.Modified;
                repos.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.OccupationId = new SelectList(reposOccupation.All(), "OccupationId", "OccupationName", client.OccupationId);
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = repos.Find(id.Value);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = repos.Find(id);
            repos.Delete(client);
            repos.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repos.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
