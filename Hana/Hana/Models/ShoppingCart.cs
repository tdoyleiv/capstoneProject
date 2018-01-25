using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hana.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartID { get; set; }
        public virtual ICollection<Product> Contents { get; set; }
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }
    }

}