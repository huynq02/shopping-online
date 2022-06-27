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
    public class OrdersController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Orders
        public ActionResult Index(string table_search, int? page)
        {
            try
            {
                int padeNum = (page ?? 1);
                int pageSize = 20;
                List<Order> orders = db.Orders.ToList();
                IQueryable<Order> od = db.Orders;
                IQueryable<Order_Details> ords = db.Order_Details;
                IQueryable<Account> accounts = (IQueryable<Account>)db.Accounts;

                if (!string.IsNullOrEmpty(table_search))
                {
                    od = od.Where(x => x.Order_note.Contains(table_search));
                    accounts = accounts.Where(x => x.account_username.Contains(table_search));
                }
                var pto = od.OrderBy(x => x.Order_Date).ToPagedList(padeNum, pageSize);
                ViewBag.table_search = table_search;
                return View(pto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Order order = db.Orders.Find(id);
                if (order == null)
                {
                    return HttpNotFound();
                }
                return View(order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.account_id = new SelectList(db.Accounts, "account_id", "account_username");
                ViewBag.Order_status_id = new SelectList(db.Order_status, "Order_status_id", "Order_status_status");
                ViewBag.shipping_id = new SelectList(db.shippings, "shipping_id", "shipping_name");
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_id,account_id,Order_note,Order_status_id,Order_total_money,Order_Date,shipping_id")] Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.account_id = new SelectList(db.Accounts, "account_id", "account_username", order.account_id);
                ViewBag.Order_status_id = new SelectList(db.Order_status, "Order_status_id", "Order_status_status", order.Order_status_id);
                ViewBag.shipping_id = new SelectList(db.shippings, "shipping_id", "shipping_name", order.shipping_id);
                return View(order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Order order = db.Orders.Find(id);
                if (order == null)
                {
                    return HttpNotFound();
                }
                ViewBag.account_id = new SelectList(db.Accounts, "account_id", "account_username", order.account_id);
                ViewBag.Order_status_id = new SelectList(db.Order_status, "Order_status_id", "Order_status_status", order.Order_status_id);
                ViewBag.shipping_id = new SelectList(db.shippings, "shipping_id", "shipping_name", order.shipping_id);
                return View(order);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_id,account_id,Order_note,Order_status_id,Order_total_money,Order_Date,shipping_id")] Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(order).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.account_id = new SelectList(db.Accounts, "account_id", "account_username", order.account_id);
                ViewBag.Order_status_id = new SelectList(db.Order_status, "Order_status_id", "Order_status_status", order.Order_status_id);
                ViewBag.shipping_id = new SelectList(db.shippings, "shipping_id", "shipping_name", order.shipping_id);
                return View(order);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Order order = db.Orders.Find(id);
                if (order == null)
                {
                    return HttpNotFound();
                }
                return View(order);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Order order = db.Orders.Find(id);
                db.Orders.Remove(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

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
