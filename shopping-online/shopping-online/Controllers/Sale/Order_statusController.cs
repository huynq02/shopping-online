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
        [Authorize(Roles = "Admin, Sale")]

        public ActionResult Index()
        {
            if (Session["account_id"] != null)
            {
                var lis = db.Order_status.ToList();
                ViewBag.image = Session["account_image"];


                ViewBag.id = Session["account_id"];
                return View("Index", lis);

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }
        //db.Order_status.ToList()
        // GET: Order_status/Create
        [Authorize(Roles = "Sale")]

        public ActionResult Create()
        {
            if (Session["account_id"] != null)
            {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                return View("Create");

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }
        [Authorize(Roles = "Sale")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_status_id,Order_status_status")] Order_status order_status)
        {

            if (Session["account_id"] != null)
            {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                if (ModelState.IsValid)
                {
                    db.Order_status.Add(order_status);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(order_status);

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }
        [Authorize(Roles = "Sale")]

        // GET: Order_status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["account_id"] != null)
            {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
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
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

        [Authorize(Roles = "Sale")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order_status order_status, int id, string status)
        {
            if (Session["account_id"] != null)
            {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                order_status.Order_status_id = id;
                if (order_status.Order_status_status == null)
                {
                    order_status.Order_status_status = status;
                }
                if (ModelState.IsValid)
                {
                    db.Entry(order_status).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Order_status");

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }



        }
        [Authorize(Roles = "Sale")]


        // GET: Order_status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["account_id"] != null)
            {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Order_status order_status = db.Order_status.Find(id);
                if (order_status == null)
                {
                    return HttpNotFound();
                }
                return View("Delete", order_status);

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }
        [Authorize(Roles = "Sale")]

        // POST: Order_status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["account_id"] != null)
            {
                try
                {
                    ViewBag.image = Session["account_image"];
                    ViewBag.id = Session["account_id"];
                    Order_status order_status = db.Order_status.Find(id);
                    db.Order_status.Remove(order_status);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Order_status");
                }
                catch
                {
                    ModelState.AddModelError("", "The status has been in use so you can not delete them");
                    Order_status order_status = db.Order_status.Find(id);
                    return View("Delete", order_status);
                }


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
