using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task.Models
{
    public class MonthWiseProductSales
    {
        public DateTime DateOfPurchase { get; set; }
        public Product ProductName { get; set; }
        public PurchaseOrderDetail Quantity { get; set; }
    }
}