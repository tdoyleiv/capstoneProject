using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hana.Models
{
    public class BillingAddress
    {
        public int BillingAddressID { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        public string Street { get; set; }
        [Required]
        public City City { get; set; }
        public int CityID { get; set; }
        [Required]
        public State State { get; set; }
        public int StateID { get; set; }
        [Required]
        public ZIP ZIP { get; set; }
        public int ZIPID { get; set; }
    }
}