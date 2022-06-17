using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopping_online.Models;
namespace shopping_online.Controllers.Sale
{
    public class Order_statusController : Controller
    {
        DBContext db = new DBContext();
        // GET: Order_status
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OrderStatus()
        {
            List<Order_status> order_Statuses = db.Order_status.ToList();
            return View(order_Statuses);
        }
    }
}