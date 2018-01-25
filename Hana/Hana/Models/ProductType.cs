using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hana.Models
{
    public class ProductType
    {
        public int ProductTypeID { get; set; }
        [Required]
        [Display(Name = "Product Type")]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}