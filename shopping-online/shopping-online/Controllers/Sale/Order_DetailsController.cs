using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shopping_online.Context;

namespace shopping_online.Controllers.Sale
{
    public class Order_DetailsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Order_Details
        public ActionResult Index()
        {
            var order_Details = db.Order_Details.Include(o => o.Order).Include(o => o.product).Include(o => o.Order_id);
            ViewBag.image = Session["account_image"];
            return View(order_Details.ToList());
        }

        // GET: Order_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Details order_Details = db.Order_Details.Find(id);
            if (order_Details == null)
            {
                return HttpNotFound();
            }
            return View(order_Details);
        }

        // GET: Order_Details/Create
        public ActionResult Create()
        {        
            ViewBag.Order_id = new SelectList(db.Orders, "Order_id", "account_id");
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_Details_id,Order_id,product_id,Order_Details_price,Order_Details_num,Order_Details_total_number")] Order_Details order_Details)
        {
            if (ModelState.IsValid)
            {
                db.Order_Details.Add(order_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Order_id = new SelectList(db.Orders, "Order_id", "account_id", order_Details.Order_id);
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name", order_Details.product_id);
            return View(order_Details);
        }

        // GET: Order_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Details order_Details = db.Order_Details.Find(id);
            if (order_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Order_id = new SelectList(db.Orders, "Order_id", "Order_note", order_Details.Order_id);
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name", order_Details.product_id);
            return View(order_Details);
        }

        // POST: Order_Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_Details_id,Order_id,product_id,Order_Details_price,Order_Details_num,Order_Details_total_number")] Order_Details order_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Order_id = new SelectList(db.Orders, "Order_id", "Order_note", order_Details.Order_id);
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name", order_Details.product_id);
            return View(order_Details);
        }

        // GET: Order_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Details order_Details = db.Order_Details.Find(id);
            if (order_Details == null)
            {
                return HttpNotFound();
            }
            return View(order_Details);
        }

        // POST: Order_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order_Details order_Details = db.Order_Details.Find(id);
            db.Order_Details.Remove(order_Details);
            db.SaveChanges();
            return RedirectToAction("Index");
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
