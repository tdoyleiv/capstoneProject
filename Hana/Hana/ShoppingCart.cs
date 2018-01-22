using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hana
{
    public class ShoppingCart
    {
        public int ShoppingCartID { get; set; }
        public List<Product> Contents { get; set; }
        public double Total { get; set; }
        public double GetTotal(List<Product> cart)
        {
            foreach(Product item in cart)
            {
                double itemCost += item.Price;;
            }
        }
    }

}