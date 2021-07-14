using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task.Models
{
    public class MonthWiseCustomerReport
    {
        public Customer CustomerName { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public PurchaseOrder Amount { get; set; }
    }
}