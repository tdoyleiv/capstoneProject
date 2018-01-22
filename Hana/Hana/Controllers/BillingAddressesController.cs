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
    public class BillingAddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BillingAddresses
        public ActionResult Index()
        {
            var billingAddresses = db.BillingAddresses.Include(b => b.City).Include(b => b.State).Include(b => b.ZIP);
            return View(billingAddresses.ToList());
        }

        // GET: BillingAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillingAddress billingAddress = db.BillingAddresses.Find(id);
            if (billingAddress == null)
            {
                return HttpNotFound();
            }
            return View(billingAddress);
        }

        // GET: BillingAddresses/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name");
            ViewBag.StateID = new SelectList(db.States, "StateID", "Name");
            ViewBag.ZIPID = new SelectList(db.ZIPs, "ZIPID", "Code");
            return View();
        }

        // POST: BillingAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BillingAddressID,Street,CityID,StateID,ZIPID")] BillingAddress billingAddress)
        {
            if (ModelState.IsValid)
            {
                db.BillingAddresses.Add(billingAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name", billingAddress.CityID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "Name", billingAddress.StateID);
            ViewBag.ZIPID = new SelectList(db.ZIPs, "ZIPID", "Code", billingAddress.ZIPID);
            return View(billingAddress);
        }

        // GET: BillingAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillingAddress billingAddress = db.BillingAddresses.Find(id);
            if (billingAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name", billingAddress.CityID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "Name", billingAddress.StateID);
            ViewBag.ZIPID = new SelectList(db.ZIPs, "ZIPID", "Code", billingAddress.ZIPID);
            return View(billingAddress);
        }

        // POST: BillingAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BillingAddressID,Street,CityID,StateID,ZIPID")] BillingAddress billingAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billingAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name", billingAddress.CityID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "Name", billingAddress.StateID);
            ViewBag.ZIPID = new SelectList(db.ZIPs, "ZIPID", "Code", billingAddress.ZIPID);
            return View(billingAddress);
        }

        // GET: BillingAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillingAddress billingAddress = db.BillingAddresses.Find(id);
            if (billingAddress == null)
            {
                return HttpNotFound();
            }
            return View(billingAddress);
        }

        // POST: BillingAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BillingAddress billingAddress = db.BillingAddresses.Find(id);
            db.BillingAddresses.Remove(billingAddress);
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
