using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hana.Models
{
    public class ZIP
    {
        public int ZIPID { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public string Code { get; set; }
    }
}