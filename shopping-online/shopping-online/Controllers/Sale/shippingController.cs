using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult Edit(int id)
        {
            shipping ship = db.shippings.FirstOrDefault(x => x.shipping_id == id);
            return View(ship);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(shipping s)
        {
            db.shippings.Add(s);
            db.SaveChanges();
            return RedirectToAction("Shipping", "Shipping");
        }
        public ActionResult Edits(shipping ship, int Id, string name, string email, string phone)
        {
           
            ship.shipping_id = Id;
            if (ship.shipping_name == null)
            {
                ship.shipping_name = name;
            }
           if(ship.shipping_email == null)
            {
                ship.shipping_email = email;
            }
           if(ship.shipping_phone == null)
            {
                ship.shipping_phone = phone;
            }
            db.Entry(ship).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Shipping", "Shipping");
        }
    }
}