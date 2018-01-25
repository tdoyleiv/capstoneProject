using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hana.Models
{
    public class Store
    {
        public int StoreID { get; set; }
        public virtual ICollection<Product> Inventory { get; set; }
        public virtual ICollection<Transaction> TransactionsList { get; set; }
    }
}