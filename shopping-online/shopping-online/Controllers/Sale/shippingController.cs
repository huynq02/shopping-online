using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using shopping_online.Models;



namespace shopping_online.Controllers.Sale
{
    public class shippingController : Controller
    {
        public class InstructorIndexData
        {
            public PagedList.IPagedList<shipping> Shipping { get; set; }

        }
        DBContext db = new DBContext();
        // GET: shipping
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Shipping(int? page)
        {
            int padeNum = (page ?? 1);
            int pageSize = 15;
            List<shipping> shippings = db.shippings.ToList();
            var pt = shippings.OrderBy(x => x.shipping_id).ToPagedList(padeNum, pageSize);
            return View(pt);
        }
        [HttpGet]
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
            if (s.shipping_name == null || s.shipping_email == null || s.shipping_phone == null)
            {
                ViewBag.thongbao = "Vui long khong de trong";
                return RedirectToAction("Create");
            }
            else
            {
                db.shippings.Add(s);
                db.SaveChanges();
                return RedirectToAction("Shipping", "Shipping");
            }

        }
        [HttpPost]
        public ActionResult Edit(shipping ship, int Id, string name, string email, string phone)
        {
            ship.shipping_id = Id;
           
                if (ship.shipping_name == null)
                {
                    ship.shipping_name = name;
                }
                if (ship.shipping_email == null)
                {
                    ship.shipping_email = email;
                }
                if (ship.shipping_phone == null)
                {
                    ship.shipping_phone = phone;
                }
                db.Entry(ship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Shipping", "Shipping");
        }
    }
}