using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Hana.Models;

namespace Hana.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        const string PromoCode = "JOY";
        // GET: Checkout
        public ActionResult Address()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Address(FormCollection values)
        {
            var order = new Transaction();
            TryUpdateModel(order);
            try
            {
                if (string.Equals(values["PromoCode"], PromoCode, StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {
                    order.Customer.Name = User.Identity.Name;
                    order.Time = DateTime.Now;
                    db.Transactions.Add(order);
                    db.SaveChanges();
                    var cart = Cart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);
                    db.SaveChanges();
                    return RedirectToAction("Complete", new { id = order.TransactionID });
                }
            }
            catch (Exception e)
            {
                e.InnerException.ToString();
                return View(order);
            }
        }
        public ActionResult Complete(int id)
        {
            bool iSValid = db.Transactions.Any(o => o.TransactionID == id && o.Customer.Name == User.Identity.Name);
            if (iSValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}