using Hana.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Hana.Classes
{
    public class EmailParameterAssembler
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public string AssembleCustomerBody(int id)
        {
            StringBuilder sb = new StringBuilder();
            var order = new Transaction();
            var shippingAddress = new ShippingAddress();
            var billingAddress = new BillingAddress();
            var customer = new ApplicationUser();
            var orderInfo = db.Transactions.Where(o => o.TransactionID == id)
                .Include(o => o.Customer.BillingAddress)
                .Include(o => o.Customer.ShippingAddress);
            foreach (var item in orderInfo)
            {
                order.TransactionID = item.TransactionID;
                order.Purchase = item.Purchase;
                order.OrderNumber = item.OrderNumber;
                order.CustomerID = item.CustomerID;
                order.Total = item.Total;
            }
           
            sb.Append("Your Order ID is: ").AppendLine().AppendLine().Append(order.OrderNumber);
            sb.AppendLine("Your order: ");
            foreach (var item in order.Purchase)
            {
                sb.AppendLine(item.Product.ProductName);
            }
            sb.AppendLine("Order Total: ").AppendLine().AppendLine().AppendLine(order.Total.ToString());
            string body = sb.ToString();
            return body;
        }
        public string AssembleOwnerBody(int id)
        {
            StringBuilder sb = new StringBuilder();
            var order = new Transaction();
            var shippingAddress = new ShippingAddress();
            var billingAddress = new BillingAddress();
            var customer = new ApplicationUser();
            var orderInfo = db.Transactions.Where(o => o.TransactionID == id)
                .Include(o => o.Customer.BillingAddress)
                .Include(o => o.Customer.ShippingAddress);
            foreach (var item in orderInfo)
            {
                order.TransactionID = item.TransactionID;
                order.Purchase = item.Purchase;
                order.OrderNumber = item.OrderNumber;
                order.CustomerID = item.CustomerID;
                order.Total = item.Total;
                shippingAddress.Street = item.Customer.ShippingAddress.Street;
                shippingAddress.City.Name = item.Customer.ShippingAddress.City.Name;
                shippingAddress.State.PostalCode = item.Customer.ShippingAddress.State.PostalCode;
                shippingAddress.ZIP.Code = item.Customer.ShippingAddress.ZIP.Code;
            }
            sb.Append("The Order ID is: ").AppendLine().AppendLine().Append(order.OrderNumber);
            sb.AppendLine("ShippingAddress: ").AppendLine().AppendLine()
                .AppendLine(shippingAddress.Street)
                .AppendLine(shippingAddress.City.Name)
                .AppendLine(shippingAddress.State.Name)
                .AppendLine(shippingAddress.ZIP.Code);
            sb.AppendLine("Product(s) ordered: ");
            foreach (var item in order.Purchase)
            {
                sb.AppendLine(item.Product.ProductName);
            }
            sb.AppendLine("Order Total: ").AppendLine().AppendLine().AppendLine(order.Total.ToString());
            string body = sb.ToString();
            return body;
        }
        public string GetCustomerEmail(int id)
        {
            var order = db.Transactions.Find(id);
            string email = order.Customer.User.Email;
            return email;
        }
        public string GetOrderID(int id)
        {
            var order = db.Transactions.Find(id);
            string orderID = order.OrderNumber.ToString();
            return orderID;
        }
    }
}