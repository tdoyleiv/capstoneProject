using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hana.Models
{
    public class State
    {
        public int StateID { get; set; }
        public string Name { get; set; }
        [Required]
        public string PostalCode { get; set; }
    }
}