using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hana.Models;
using System.ComponentModel.DataAnnotations;

namespace Hana.ViewModels
{
    public class CartViewModel
    {
        public ICollection<ShoppingCart> Contents { get; set; }
        [DataType(DataType.Currency)]
        public decimal CartTotal { get; set; }
    }
}