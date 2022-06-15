using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopping_online.Models;

namespace shopping_online.Controllers
{
    public class Order_DetailsController : Controller
    {
        DBContext db = new DBContext();
        // GET: Order_Details
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Oderdetails() {
            return View(db.Order_Details.ToList());
        }
       
        }
}