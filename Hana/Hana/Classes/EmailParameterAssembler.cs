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
            var order = db.Transactions.Find(id);
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
            var order = db.Transactions.Find(id);
            sb.Append("The Order ID is: ").AppendLine().AppendLine().Append(order.OrderNumber);
            sb.AppendLine("ShippingAddress: ").AppendLine().AppendLine()
            .AppendLine(order.Street)
            .AppendLine(order.City)
            .AppendLine(order.State)
            .AppendLine(order.PostalCode);
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
            string email = order.Email;
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