using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Hana.Classes;
using Hana.Models;
using System.Text;

namespace Hana.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        const string PromoCode = "JOY";
        // GET: Checkout
        public ActionResult AddressAndPayment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
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
                    order.Email = User.Identity.Name;
                    order.Time = DateTime.Now;
                    order.OrderNumber = Guid.NewGuid();
                    var cart = Cart.GetCart(this.HttpContext);
                    order.TransactionID = cart.CreateOrder(order);
                    var orderedProduct = db.OrderedProducts.Where( o => o.TransactionID == order.TransactionID);
                    foreach (var item in orderedProduct)
                    {
                        order.ProductID = item.ProductID;
                    }
                    foreach (var value in values)
                    {
                        order.FirstName = values["FirstName"];
                        order.LastName = values["LastName"];
                        order.Street = values["Street"];
                        order.City = values["City"];
                        order.State = values["State"];
                        order.PostalCode = values["PostalCode"];
                        order.Country = values["Country"];
                        order.Phone = values["Phone"];
                    }
                        db.Transactions.Add(order);
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
            EmailParameterAssembler emailAssembler = new EmailParameterAssembler();
            bool iSValid = db.Transactions.Any(o => o.TransactionID == id);
            if (iSValid)
            {
                string orderID = emailAssembler.GetOrderID(id);
                string body = emailAssembler.AssembleOwnerBody(id);
                string recipient = emailAssembler.GetCustomerEmail(id);
                string customerBody = emailAssembler.AssembleCustomerBody(id);
                MailGun.SendOrderDetails(orderID, body);
                MailGun.SendCustomerConfirmation(recipient, customerBody);
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}