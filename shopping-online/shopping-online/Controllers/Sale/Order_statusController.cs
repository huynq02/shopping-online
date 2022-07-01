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
    public class Order_statusController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Order_status
        public ActionResult Index()
        {
            var a = db.Order_status.ToList();


            return View("Index", a);
        }
        //db.Order_status.ToList()
        // GET: Order_status/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_status_id,Order_status_status")] Order_status order_status)
        {

            if (ModelState.IsValid)
            {
                db.Order_status.Add(order_status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order_status);
        }

        // GET: Order_status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_status order_status = db.Order_status.Find(id);
            if (order_status == null)
            {
                return HttpNotFound();
            }
            return View("Edit", order_status);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order_status order_status, int id, string status)
        {
            order_status.Order_status_id = id;
            if (order_status.Order_status_status == null)
            {
                order_status.Order_status_status = status;
            }

            db.Entry(order_status).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Order_status");


        }

        // GET: Order_status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_status order_status = db.Order_status.Find(id);
            if (order_status == null)
            {
                return HttpNotFound();
            }
            return View(order_status);
        }

        // POST: Order_status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order_status order_status = db.Order_status.Find(id);
            db.Order_status.Remove(order_status);
            db.SaveChanges();
            return RedirectToAction("Index", "Order_status");
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
