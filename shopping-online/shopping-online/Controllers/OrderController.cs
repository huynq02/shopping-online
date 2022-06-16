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
       
        public ActionResult Orders()
        {
           
            List<Order> orders = db.Orders.ToList();
            return View(orders);

        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            Order order = db.Orders.FirstOrDefault(x => x.Order_id == id);
            ViewBag.orderId = order.Order_id;
            if(order == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(order);
        }
       public ActionResult Create()
        {
            return View();
        }
    }
}