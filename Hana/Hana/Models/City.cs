using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hana.Models
{
    public class City
    {
        public int CityID { get; set; }
        [Required(ErrorMessage = "This a required field")]
        public string Name { get; set; }
    }
}