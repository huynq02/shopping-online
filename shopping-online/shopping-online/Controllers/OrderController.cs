using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopping_online.Models;
namespace shopping_online.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            DBContext dBContext = new DBContext();
            List<Order> orders = dBContext.Orders.ToList();
            return View(orders);
        }
    }
}