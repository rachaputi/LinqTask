using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Models;

namespace Task.Controllers
{
    public class MultipleTablesController : Controller
    {
        // GET: MultipleTables
        public ActionResult ListOfPurchaseOrderAgainstCustomer()
        {
            ShoppingEntities iEntity = new ShoppingEntities();
            List<Customer> customers = iEntity.Customers.ToList();
            List<PurchaseOrder> purchaseOrder = iEntity.PurchaseOrders.ToList();
            List<Product> product = iEntity.Products.ToList();
            List<PurchaseOrderDetail> purchaseOrderDetail = iEntity.PurchaseOrderDetails.ToList();
            var Temp = from p in product
                     join pod in purchaseOrderDetail on p.ProductID equals pod.ProductID
                     join po in purchaseOrder on pod.POID equals po.POID
                     join c in customers on po.CustomerID equals c.CustomerID
                     orderby c.CustomerID
                     select new CustomerProducts
                     {
                         CustomerName = c,
                         POID = po,
                         ProductName = p,
                         Price = pod
                     };

            return View(Temp);
        }
        public ActionResult MonthWiseCustomerReportWithProducts()
        {
            ShoppingEntities iEntity = new ShoppingEntities();
            List<Customer> customers = iEntity.Customers.ToList();
            List<PurchaseOrder> purchaseOrder = iEntity.PurchaseOrders.ToList();
            var Temp = from po in purchaseOrder
                     join c in customers on po.CustomerID equals c.CustomerID
                     orderby po.DateOfPurchase.Month
                     select new MonthWiseCustomerReport
                     {
                         CustomerName = c,
                         DateOfPurchase = po.DateOfPurchase,
                         Amount = po
                     };
            return View(Temp);
        }
        public ActionResult ProductSalesReportMonthWise()
        {
            ShoppingEntities iEntity = new ShoppingEntities();
            List<Product> products = iEntity.Products.ToList();
            List<PurchaseOrder> purchaseOrder = iEntity.PurchaseOrders.ToList();
            List<PurchaseOrderDetail> purchaseOrderDetail = iEntity.PurchaseOrderDetails.ToList();
            var Temp = from p in products
                     join po in purchaseOrder on p.ProductID equals po.ProductID
                     join pod in purchaseOrderDetail on po.POID equals pod.POID
                     orderby po.DateOfPurchase.Month
                     select new MonthWiseProductSales
                     {
                         DateOfPurchase = po.DateOfPurchase,
                         ProductName = p,
                         Quantity = pod
                     };
            return View(Temp);
        }
      
    }
}