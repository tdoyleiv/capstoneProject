using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hana.Models
{
    public class EmailAddress
    {
        public int EmailAddressID { get; set; }
        [Required(ErrorMessage = "An email address is required")]
        [EmailAddress(ErrorMessage = "That is an invalid email address")]
        public string Name { get; set; }
    }
}