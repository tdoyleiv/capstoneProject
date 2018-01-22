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
        public string Street { get; set; }
        public City City { get; set; }
        public int CityID { get; set; }
        public State State { get; set; }
        public int StateID { get; set; }
        public ZIP ZIP { get; set; }
        public int ZIPID { get; set; }
    }
}