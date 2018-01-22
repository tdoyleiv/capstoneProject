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
    public class ShippingAddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShippingAddresses
        public ActionResult Index()
        {
            var shippingAddresses = db.ShippingAddresses.Include(s => s.City).Include(s => s.State).Include(s => s.ZIP);
            return View(shippingAddresses.ToList());
        }

        // GET: ShippingAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingAddress shippingAddress = db.ShippingAddresses.Find(id);
            if (shippingAddress == null)
            {
                return HttpNotFound();
            }
            return View(shippingAddress);
        }

        // GET: ShippingAddresses/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name");
            ViewBag.StateID = new SelectList(db.States, "StateID", "Name");
            ViewBag.ZIPID = new SelectList(db.ZIPs, "ZIPID", "Code");
            return View();
        }

        // POST: ShippingAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShippingAddressID,Street,CityID,StateID,ZIPID,IsBilling")] ShippingAddress shippingAddress)
        {
            if (ModelState.IsValid)
            {
                db.ShippingAddresses.Add(shippingAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name", shippingAddress.CityID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "Name", shippingAddress.StateID);
            ViewBag.ZIPID = new SelectList(db.ZIPs, "ZIPID", "Code", shippingAddress.ZIPID);
            return View(shippingAddress);
        }

        // GET: ShippingAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingAddress shippingAddress = db.ShippingAddresses.Find(id);
            if (shippingAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name", shippingAddress.CityID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "Name", shippingAddress.StateID);
            ViewBag.ZIPID = new SelectList(db.ZIPs, "ZIPID", "Code", shippingAddress.ZIPID);
            return View(shippingAddress);
        }

        // POST: ShippingAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShippingAddressID,Street,CityID,StateID,ZIPID,IsBilling")] ShippingAddress shippingAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shippingAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name", shippingAddress.CityID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "Name", shippingAddress.StateID);
            ViewBag.ZIPID = new SelectList(db.ZIPs, "ZIPID", "Code", shippingAddress.ZIPID);
            return View(shippingAddress);
        }

        // GET: ShippingAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingAddress shippingAddress = db.ShippingAddresses.Find(id);
            if (shippingAddress == null)
            {
                return HttpNotFound();
            }
            return View(shippingAddress);
        }

        // POST: ShippingAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShippingAddress shippingAddress = db.ShippingAddresses.Find(id);
            db.ShippingAddresses.Remove(shippingAddress);
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
