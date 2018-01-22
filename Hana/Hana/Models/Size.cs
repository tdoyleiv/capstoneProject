using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hana.Models
{
    public class Size
    {
        public int SizeID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}