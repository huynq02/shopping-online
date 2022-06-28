using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using shopping_online.Context;

namespace shopping_online.Controllers.Sale
{
    public class shippingController : Controller
    {
        private DBContext db = new DBContext();

        // GET: shipping
        public ActionResult Index(string table_search, int? page)
        {
            int padeNum = (page ?? 1);
            int pageSize = 10;
            List<shipping> ship = db.shippings.ToList();
            IQueryable<shipping> pt = db.shippings;

            if (!string.IsNullOrEmpty(table_search))
            {
                pt = pt.Where(x => x.shipping_name.Contains(table_search) || x.shipping_email.Contains(table_search) || x.shipping_phone.Contains(table_search));
            }
            var pts = pt.OrderBy(x => x.shipping_id).ToPagedList(padeNum, pageSize);
            ViewBag.table_search = table_search;
            return View(pts);
        }

        // GET: shipping/Details/5
       

        // GET: shipping/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: shipping/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "shipping_id,shipping_name,shipping_email,shipping_phone")] shipping shipping)
        {
            if (ModelState.IsValid)
            {
                db.shippings.Add(shipping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shipping);
        }

        // GET: shipping/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shipping shipping = db.shippings.Find(id);
            if (shipping == null)
            {
                return HttpNotFound();
            }
            return View(shipping);
        }

        // POST: shipping/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "shipping_id,shipping_name,shipping_email,shipping_phone")] shipping shipping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipping);
        }

        // GET: shipping/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shipping shipping = db.shippings.Find(id);
            if (shipping == null)
            {
                return HttpNotFound();
            }
            return View(shipping);
        }
        [HttpPost]
        public JsonResult IsShipuse(int shipId)
        {
            return Json(!db.Orders.Any(x => x.shipping_id == shipId),
                                                 JsonRequestBehavior.AllowGet);
        }
        // POST: shipping/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "shipping_id,shipping_name,shipping_email,shipping_phone")] shipping shipping)
        {
            if (db.Orders.Any(x => x.shipping_id == shipping.shipping_id))
            {
                ModelState.AddModelError("shipping_id", "Ship already in use");
            }
            //shipping shipping = db.shippings.Find(id);
            //db.shippings.Remove(shipping);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            if (ModelState.IsValid)
            {
                db.Entry(shipping).State = EntityState.Modified;
                db.shippings.Remove(shipping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipping);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
