using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hana
{
    public class BillingAddress
    {
        public int BillingAddressID { get; set; }
        public string Street { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public ZIP ZIP { get; set; }
    }
}