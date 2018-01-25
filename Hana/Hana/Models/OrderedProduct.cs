using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hana.Models
{
    public class OrderedProduct
    {
        public int OrderedProductID { get; set; }
        public virtual Product Product { get; set; }
        [Column(Order = 0)]
        public int ProductID { get; set; }
        public virtual Transaction Transaction { get; set; }
        [Column(Order = 1)]
        public int TransactionID { get; set; }
        public int Quantity { get; set; }
    }
}