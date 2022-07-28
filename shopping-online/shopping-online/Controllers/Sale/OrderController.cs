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
    public class OrderController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Order
        [Authorize(Roles = "Admin, Sale")]
        public ActionResult Index(string table_search, int? page)
        {
            if (Session["account_id"] != null)
            {
                ViewBag.image = Session["account_image"];
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
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                return View(order);

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
           
        }

        // GET: Order/Create
        [Authorize(Roles = "Sale")]
        public ActionResult Create()
        {
            if (Session["account_id"] != null)
            {
                ViewBag.account_id = new SelectList(db.Accounts, "account_id", "account_username");
                ViewBag.Order_status_id = new SelectList(db.Order_status, "Order_status_id", "Order_status_status");
                ViewBag.shipping_id = new SelectList(db.shippings, "shipping_id", "shipping_name");
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                return View();

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
           
        }
        [Authorize(Roles = "Sale")]

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_id,account_id,Order_note,Order_status_id,Order_total_money,Order_Date,shipping_id")] Order order)
        {
            if (Session["account_id"] != null)
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
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                return View(order);

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
           
        }
        [Authorize(Roles = "Sale")]

        public ActionResult Create_order_detail()
        {
            if (Session["account_id"] != null)
            {
                ViewBag.Order_id = new SelectList(db.Orders, "Order_id", "Order_note");
                ViewBag.product_id = new SelectList(db.products, "product_id", "product_name");
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                return View();

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
          
        }

        // POST: Order_Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Sale")]

        public ActionResult Create_order_detail([Bind(Include = "Order_Details_id,Order_id,product_id,Order_Details_price,Order_Details_num,Order_Details_total_number")] Order_Details order_Details)
        {
            if (Session["account_id"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Order_Details.Add(order_Details);
                    db.SaveChanges();
                    ViewBag.image = Session["account_image"];
                    ViewBag.id = Session["account_id"];
                    return RedirectToAction("Create");

                }

                ViewBag.Order_id = new SelectList(db.Orders, "Order_id", "Order_note", order_Details.Order_id);
                ViewBag.product_id = new SelectList(db.products, "product_id", "product_name", order_Details.product_id);
                return View(order_Details);

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
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
                bool getstatus1 = db.Orders.Any(p => p.Order_id == id && p.Order_status_id == 5);
                bool getstatus2 = db.Orders.Any(p => p.Order_id == id && p.Order_status_id == 4);
                if (order.Order_status_id != 5 && order.Order_status_id != 4)
                {

                    ModelState.AddModelError("", "The Order has been in transfer. Are you sure to delete them?");
                }
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

        [HttpGet]
        public JavaScriptResult WarningMessage()
        {
            var msg = "alert('Are you sure want to delete Order because this order has been transform?');";
            return new JavaScriptResult() { Script = msg };
        }
        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            if (Session["account_id"] != null)
            {
                

                Order order = db.Orders.Find(id);
                bool getstatus1 = db.Orders.Any(p => p.Order_id == id && p.Order_status_id == 5);
                bool getstatus2 = db.Orders.Any(p => p.Order_id == id && p.Order_status_id == 4);
                if (order.Order_status_id != 5 && order.Order_status_id != 4)
                {

                    ModelState.AddModelError("", "The Order has been in transfer. Are you sure to delete them?");
                }
              
                var details = db.Order_Details.Where(p => p.Order_id == id).ToList();
                foreach (var item in details)
                {
                    db.Order_Details.Remove(item);
                    db.SaveChanges();
                }
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
