using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hana.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartID { get; set; }
        public string SessionID { get; set; }
        public virtual Product Product { get; set; }
        public int ProductID { get; set; }
        public int Count { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }
    }

}