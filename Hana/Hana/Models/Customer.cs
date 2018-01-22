using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hana.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public int PhoneNumberID { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int ShoppingCartID { get; set; }
        public EmailAddress EmailAddress { get; set; }
        public int EmailAddressID { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public int ShippingAddressID { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public int BillingAddressID { get; set; }
        public CreditCard CreditCard { get; set; }
        public int CreditCardID { get; set; }
    }
}