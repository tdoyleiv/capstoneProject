using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hana.Models;

namespace Hana.Controllers
{
    public class ZIPsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ZIPs
        public ActionResult Index()
        {
            return View(db.ZIPs.ToList());
        }

        // GET: ZIPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZIP zIP = db.ZIPs.Find(id);
            if (zIP == null)
            {
                return HttpNotFound();
            }
            return View(zIP);
        }

        // GET: ZIPs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZIPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZIPID,Code")] ZIP zIP)
        {
            if (ModelState.IsValid)
            {
                db.ZIPs.Add(zIP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zIP);
        }

        // GET: ZIPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZIP zIP = db.ZIPs.Find(id);
            if (zIP == null)
            {
                return HttpNotFound();
            }
            return View(zIP);
        }

        // POST: ZIPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZIPID,Code")] ZIP zIP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zIP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zIP);
        }

        // GET: ZIPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZIP zIP = db.ZIPs.Find(id);
            if (zIP == null)
            {
                return HttpNotFound();
            }
            return View(zIP);
        }

        // POST: ZIPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZIP zIP = db.ZIPs.Find(id);
            db.ZIPs.Remove(zIP);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
