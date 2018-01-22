using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hana.Models
{
    public class PhoneNumber
    {
        public int PhoneNumberID { get; set; }
        [Required]
        [Phone]
        public string Number { get; set; }
    }
}