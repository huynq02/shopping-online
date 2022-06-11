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
        DBContext db = new DBContext();
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Orders()
        {
           
            List<Order> orders = db.Orders.ToList();
            return View(orders);

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}