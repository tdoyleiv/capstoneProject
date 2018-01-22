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
        public string Name { get; set; }
    }
}