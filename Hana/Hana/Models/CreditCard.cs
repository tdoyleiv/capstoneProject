﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hana.Models
{
    public class CreditCard
    {
        public int CreditCardID { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        public string Cardholder { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        [CreditCard]
        public string CCNumber { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public int BillingAddressID { get; set; }
    }
}