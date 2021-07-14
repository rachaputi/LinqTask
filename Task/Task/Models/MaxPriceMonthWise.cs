using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task.Models
{
    public class MaxPriceMonthWise
    {
        public DateTime DateOfPurchase { get; set; }
        public PurchaseOrderDetail POID { get; set; }
        public decimal Price { get; set; }
    }
}