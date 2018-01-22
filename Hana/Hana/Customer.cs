using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hana
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public ShoppingCart Cart { get; set; }
        public EmailAddress Email { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public Payment Payment { get; set; }
    }
}