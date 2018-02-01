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
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.BillingAddress).Include(c => c.CreditCard).Include(c => c.EmailAddress).Include(c => c.PhoneNumber).Include(c => c.ShippingAddress).Include(c => c.ShoppingCart);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.BillingAddressID = new SelectList(db.BillingAddresses, "BillingAddressID", "Street");
            ViewBag.CreditCardID = new SelectList(db.CreditCards, "CreditCardID", "Cardholder");
            ViewBag.EmailAddressID = new SelectList(db.EmailAddresses, "EmailAddressID", "Name");
            ViewBag.PhoneNumberID = new SelectList(db.PhoneNumbers, "PhoneNumberID", "Number");
            ViewBag.ShippingAddressID = new SelectList(db.ShippingAddresses, "ShippingAddressID", "Street");
            ViewBag.ShoppingCartID = new SelectList(db.ShoppingCarts, "ShoppingCartID", "SessionID");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,UserID,Name,PhoneNumberID,ShoppingCartID,EmailAddressID,ShippingAddressID,BillingAddressID,CreditCardID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BillingAddressID = new SelectList(db.BillingAddresses, "BillingAddressID", "Street", customer.BillingAddressID);
            ViewBag.CreditCardID = new SelectList(db.CreditCards, "CreditCardID", "Cardholder", customer.CreditCardID);
            ViewBag.EmailAddressID = new SelectList(db.EmailAddresses, "EmailAddressID", "Name", customer.EmailAddressID);
            ViewBag.PhoneNumberID = new SelectList(db.PhoneNumbers, "PhoneNumberID", "Number", customer.PhoneNumberID);
            ViewBag.ShippingAddressID = new SelectList(db.ShippingAddresses, "ShippingAddressID", "Street", customer.ShippingAddressID);
            ViewBag.ShoppingCartID = new SelectList(db.ShoppingCarts, "ShoppingCartID", "SessionID", customer.ShoppingCartID);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.BillingAddressID = new SelectList(db.BillingAddresses, "BillingAddressID", "Street", customer.BillingAddressID);
            ViewBag.CreditCardID = new SelectList(db.CreditCards, "CreditCardID", "Cardholder", customer.CreditCardID);
            ViewBag.EmailAddressID = new SelectList(db.EmailAddresses, "EmailAddressID", "Name", customer.EmailAddressID);
            ViewBag.PhoneNumberID = new SelectList(db.PhoneNumbers, "PhoneNumberID", "Number", customer.PhoneNumberID);
            ViewBag.ShippingAddressID = new SelectList(db.ShippingAddresses, "ShippingAddressID", "Street", customer.ShippingAddressID);
            ViewBag.ShoppingCartID = new SelectList(db.ShoppingCarts, "ShoppingCartID", "SessionID", customer.ShoppingCartID);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,UserID,Name,PhoneNumberID,ShoppingCartID,EmailAddressID,ShippingAddressID,BillingAddressID,CreditCardID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BillingAddressID = new SelectList(db.BillingAddresses, "BillingAddressID", "Street", customer.BillingAddressID);
            ViewBag.CreditCardID = new SelectList(db.CreditCards, "CreditCardID", "Cardholder", customer.CreditCardID);
            ViewBag.EmailAddressID = new SelectList(db.EmailAddresses, "EmailAddressID", "Name", customer.EmailAddressID);
            ViewBag.PhoneNumberID = new SelectList(db.PhoneNumbers, "PhoneNumberID", "Number", customer.PhoneNumberID);
            ViewBag.ShippingAddressID = new SelectList(db.ShippingAddresses, "ShippingAddressID", "Street", customer.ShippingAddressID);
            ViewBag.ShoppingCartID = new SelectList(db.ShoppingCarts, "ShoppingCartID", "SessionID", customer.ShoppingCartID);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
