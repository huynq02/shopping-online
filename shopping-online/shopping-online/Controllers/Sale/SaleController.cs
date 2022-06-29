using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers.Sale
{
    public class SaleController : Controller
    {
        DBContext db = new DBContext();
        // GET: Sale
        public ActionResult Index()
        {
            var lsProHaveOd = db.Order_Details.Where(x => x.product_id.HasValue).ToList();
            var numProHaveOd = db.Order_Details.Where(x => x.product_id.HasValue).FirstOrDefault();

            var numOrder = db.Orders.Count();
            var liscushaveOd = db.Orders.Where(x => x.account_id.HasValue).ToList();
            var numcushaveOd = db.Orders.Where(x => x.account_id.HasValue).FirstOrDefault();
            var cus = db.Roles.Where(x => x.Role_name == "Customer").FirstOrDefault();
            // trong 4 ô thì để :
            // số customer có order / số customer của của hàng => lược ra khách hàng tiềm năng có hoạt động
            // tổng số tiền tháng này của order trong tháng này
            // tổng số product
            // số order ngày hôm nay
            var list_customer_have_order = db.Orders.ToList(); // để sử dụng hàm count đếm số customer có order
            var list_customer = db.Accounts.Where(x => x.Role.Role_name == "Customer").ToList();
            var list_Order_today = db.Orders.Where(x => EntityFunctions.TruncateTime(x.Order_Date) == EntityFunctions.TruncateTime(DateTime.Today)).ToList();
            var list_Order_on_mounth = db.Orders.Where(x => EntityFunctions.TruncateTime(x.Order_Date) == EntityFunctions.TruncateTime(DateTime.Today)).ToList();
            var list_Product = db.products.ToList();
            


            double sum = 0;
            var cus_order = db.Orders.Where(x => x.account_id.HasValue).ToList();
            var lsOrder = db.Orders.ToList();
            foreach (var item in lsOrder)
            {
                sum += item.Order_total_money;
            }
         
            SaleDashboard sale = new SaleDashboard();
            sale.cus_order = lsOrder;
            sale.acc_order = list_customer;
            
            return View(sale);
        }
    }
    
}