using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hana.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeID {get; set;}
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public Size Size { get; set; }
        public int SizeID { get; set; }
        public int Quantity { get; set; }
        public bool IsSoldOut { get; set; }
    }
}