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
        [Required(ErrorMessage = "A phone number is required")]
        [Phone(ErrorMessage = "That is an invalid phone number")]
        public string Number { get; set; }
    }
}