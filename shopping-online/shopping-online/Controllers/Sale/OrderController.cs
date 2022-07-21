using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using PagedList;
using shopping_online.Common;
using shopping_online.Context;
using shopping_online.Models;

namespace shopping_online.Controllers.Sale
{
    public class OrderController : Controller
    {
        private DBContext db = new DBContext();



        // GET: Order
        [Authorize(Roles = "Admin, Sale")]
        public ActionResult Index(string table_search, int? page)
        {
            if (Session["account_id"] != null)
            {
                int padeNum = (page ?? 1);
                int pageSize = 20;
                List<Order> orders = db.Orders.ToList();
                IQueryable<Order> od = db.Orders;
                IQueryable<Order_Details> ords = db.Order_Details;
                IQueryable<Account> accounts = db.Accounts;

                if (!string.IsNullOrEmpty(table_search))
                {
                    od = od.Where(x => x.Order_note.Contains(table_search));
                    accounts = accounts.Where(x => x.account_username.Contains(table_search));
                }
                var pto = od.OrderBy(x => x.Order_Date).ToPagedList(padeNum, pageSize);
                ViewBag.table_search = table_search;
                ViewBag.id = Session["account_id"];
                return View("Index", pto);

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
           
        }

        // GET: Order/Details/5
        [Authorize(Roles = "Admin, Sale")]
        public ActionResult Details(int? id)
        {
            if (Session["account_id"] != null)
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
                ViewBag.id = Session["account_id"];
                return View(order);

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
           
        }
        private int GetID(string username)
        {
            int id = (from user in db.Accounts
                      where user.account_username.ToLower() == username.ToLower()
                      select user.account_id).SingleOrDefault();
            return id;
        }

        [Authorize(Roles = "Sale")]

        // GET: Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["account_id"] != null)
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
                ViewBag.id = Session["account_id"];
                return View("Edit", order);

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
           
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Sale")]

        public ActionResult Edit([Bind(Include = "Order_id,account_id,Order_note,Order_status_id,Order_total_money,Order_Date,shipping_id")] Order order)
        {
            if (Session["account_id"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(order).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.id = Session["account_id"];
                    return RedirectToAction("Index");
                }
                ViewBag.id = Session["account_id"];
                ViewBag.account_id = new SelectList(db.Accounts, "account_id", "account_username", order.account_id);
                ViewBag.Order_status_id = new SelectList(db.Order_status, "Order_status_id", "Order_status_status", order.Order_status_id);
                ViewBag.shipping_id = new SelectList(db.shippings, "shipping_id", "shipping_name", order.shipping_id);
                return View(order);

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
           
        }

        // GET: Order/Delete/5
        [Authorize(Roles = "Sale")]

        public ActionResult Delete(int? id)
        {
            if (Session["account_id"] != null)
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
                ViewBag.id = Session["account_id"];
                return View("Delete", order);

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }
        [Authorize(Roles = "Sale")]

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["account_id"] != null)
            {Order order = db.Orders.Find(id);
                Order_Details order_Details = db.Order_Details.Where(o => o.Order_id == id).FirstOrDefault();
                db.Order_Details.Remove(order_Details);
                db.Orders.Remove(order);
                db.SaveChanges();
                ViewBag.id = Session["account_id"];
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Login", "Login");
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
