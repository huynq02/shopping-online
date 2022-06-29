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
            var numProHaveOd = db.Order_Details.Where(x => x.product_id.HasValue).Count();
            var lsOrder = db.Orders.ToList();
            var numOrder = db.Orders.Count();
            var liscushaveOd = db.Orders.Where(x => x.account_id.HasValue).ToList();
            var numcushaveOd = db.Orders.Where(x => x.account_id.HasValue).FirstOrDefault();
            var cus = db.Roles.Where(x => x.Role_name == "Customer").FirstOrDefault();
            double sum = 0;
            foreach (var item in lsOrder)
            {
                sum += item.Order_total_money;
            }
            var ordcre = db.Orders.Where(x => EntityFunctions.TruncateTime(x.Order_Date) == EntityFunctions.TruncateTime(DateTime.Now)).FirstOrDefault();
            SaleDashboard sale = new SaleDashboard();
            
            
            return View(); 
        }
    }
}