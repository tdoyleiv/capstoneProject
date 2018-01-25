using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hana.Models
{
    public partial class Cart
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public string CartID { get; set; }
        public const string CartSessionKey = "shoppingcartID";
        public static Cart GetCart(HttpContextBase context)
        {
            var cart = new Cart();
            cart.CartID = cart.GetCartID(context);
            return cart;
        }
        public static Cart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddtoCart(Product product)
        {
            var cartItem = db.ShoppingCarts.SingleOrDefault(c => c.ShoppingCartID == CartID && c.ProductID == product.ProductID);
            if (cartItem == null)
            {
                cartItem = new ShoppingCart
                {
                    ProductID = product.ProductID,
                    ShoppingCartID = CartID,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                db.ShoppingCarts.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }
            db.SaveChanges();
        }
        public int RemoveFromCart(int id)
        {
            var cartItem = db.ShoppingCarts.SingleOrDefault(c => c.ShoppingCartID == CartID && c.ProductID == id);
            int itemCount = 0;
            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    db.ShoppingCarts.Remove(cartItem);
                }
                db.SaveChanges();
            }
            return itemCount;
        }
        public void EmptyCart()
        {
            var cartItems = db.ShoppingCarts.Where(c => c.ShoppingCartID == CartID);
            foreach (var cartItem in cartItems)
            {
                db.ShoppingCarts.Remove(cartItem);
            }
            db.SaveChanges();
        }
        public List<ShoppingCart> GetCartItems()
        {
            return db.ShoppingCarts.Where(c => c.ShoppingCartID == CartID).ToList();
        }
        public int GetCount()
        {
            int? count = (from cartItems in db.ShoppingCarts where cartItems.ShoppingCartID == CartID select (int?) cartItems.Count).Sum();
            return count ?? 0;
        }
        public decimal GetTotal()
        {
            decimal? total = (from cartItems in db.ShoppingCarts where cartItems.ShoppingCartID == CartID select (int?)cartItems.Count * cartItems.Product.Price).Sum();
            return total ?? decimal.Zero;
        }
        public int CreateOrder(Transaction order)
        {
            decimal orderTotal = 0;
            var cartItems = GetCartItems();
            foreach (var item in cartItems)
            {
                var orderedProduct = new OrderedProduct()
                {
                    ProductID = item.ProductID,
                    TransactionID = order.TransactionID,
                    Quantity = item.Count
                };
                orderTotal += (item.Count * item.Product.Price);
                db.OrderedProducts.Add(orderedProduct);
            }
            order.Total = orderTotal;
            db.SaveChanges();
            EmptyCart();
            return order.TransactionID;
        }
        public string GetCartID(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartID = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartID.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        public void MigrateCart (string userName)
        {
            var cart = db.ShoppingCarts.Where(c => c.ShoppingCartID == CartID);
            foreach (ShoppingCart item in cart)
            {
                item.ShoppingCartID = userName;
            }
            db.SaveChanges();
        }
    }
}