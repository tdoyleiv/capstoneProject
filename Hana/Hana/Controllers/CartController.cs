using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Hana.Models;
using Hana.ViewModels;

namespace Hana.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Cart.GetCart(this.HttpContext);
            var viewModel = new CartViewModel
                {
                    Contents = cart.GetCartItems(),
                    CartTotal = cart.GetTotal()
                };
            return View(viewModel);
        }
        public ActionResult AddToCart(int id)
        {
            var addedProduct = db.Products.Single(p => p.ProductID == id);
            var cart = Cart.GetCart(this.HttpContext);
            cart.AddtoCart(addedProduct);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = Cart.GetCart(this.HttpContext);
            string productName = db.ShoppingCarts.FirstOrDefault(i => i.ProductID == id).Product.ProductName;
            int itemCount = cart.RemoveFromCart(id);
            var results = new CartRemoveViewModel
            {
                Message = Server.HtmlEncode(productName) + " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteID = id
            };
            return Json(results);
        }
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = Cart.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}