using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopping_online.Models;
namespace shopping_online.Controllers.Sale
{
    public class shippingController : Controller
    {
        DBContext db = new DBContext();
        // GET: shipping
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Shipping()
        {
            List<shipping> shippings = db.shippings.ToList();
            return View(shippings);
        }
    }
}