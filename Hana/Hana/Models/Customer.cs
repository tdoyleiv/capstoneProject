using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hana.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        public string Name { get; set; }
        [Required]
        public PhoneNumber PhoneNumber { get; set; }
        public int PhoneNumberID { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int ShoppingCartID { get; set; }
        [Required]
        public EmailAddress EmailAddress { get; set; }
        public int EmailAddressID { get; set; }
        [Required]
        public ShippingAddress ShippingAddress { get; set; }
        public int ShippingAddressID { get; set; }
        [Required]
        public BillingAddress BillingAddress { get; set; }
        public int BillingAddressID { get; set; }
        public CreditCard CreditCard { get; set; }
        public int CreditCardID { get; set; }
    }
}