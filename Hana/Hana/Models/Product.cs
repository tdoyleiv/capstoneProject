using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [StringLength(500)]
        public string ProductDescription { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public Size Size { get; set; }
        public int SizeID { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Updated On")]
        [Column(TypeName = "datetime2")]
        public DateTime LastUpdated { get; set; }
        public bool IsSoldOut { get; set; }
    }
}