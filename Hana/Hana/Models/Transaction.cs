using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hana.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        [Required]
        public Customer Customer { get; set; }
        public int CustomerID { get; set; }
        [Required]
        public CreditCard CreditCard {get; set; }
        public int CreditCardID { get; set; }
        public virtual Product Product { get; set; }
        public int ProductID { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        public decimal Total { get; set; }
        public DateTime Time { get; set; }
    }
}