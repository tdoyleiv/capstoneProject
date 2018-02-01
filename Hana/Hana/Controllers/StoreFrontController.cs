using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hana.Models;
using System.Net;

namespace Hana.Controllers
{
    public class StoreFrontController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        // GET: StoreFront
        public ActionResult Store(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType productType = db.ProductTypes.Find(id);
            if (productType == null)
            {
                return RedirectToAction("Index");
            }
            return View(productType);
        }
    }
}