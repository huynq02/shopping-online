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

    public class shippingsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: shippings
        [Authorize(Roles = "Admin, Sale")]
        public ActionResult Index(string table_search, int? page)
        {
            if (Session["account_id"] != null)
            {
                ViewBag.image = Session["account_image"];
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
                ViewBag.id = Session["account_id"];
                return View("Index", pts);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }



        // GET: shippings/Create
        [Authorize(Roles = "Sale")]
        public ActionResult Create()
        {
            if (Session["account_id"] != null)
            {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                return View("Create");
            }
            else { return RedirectToAction("Login", "Login"); }
        }

        // POST: shippings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "shipping_id,shipping_name,shipping_email,shipping_phone")] shipping shipping)
        {
            if (ModelState.IsValid)
            {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                db.shippings.Add(shipping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shipping);
        }

        // GET: shippings/Edit/5
        [Authorize(Roles = "Sale")]
        public ActionResult Edit(int? id)
        {
            ViewBag.image = Session["account_image"];
            ViewBag.id = Session["account_id"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shipping shipping = db.shippings.Find(id);
            if (shipping == null)
            {
                return HttpNotFound();
            }
            return View("Edit", shipping);
        }

        // POST: shippings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "shipping_id,shipping_name,shipping_email,shipping_phone")] shipping shipping)
        {
            ViewBag.image = Session["account_image"];
            ViewBag.id = Session["account_id"];
            if (ModelState.IsValid)
            {
                db.Entry(shipping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipping);
        }

        // GET: shippings/Delete/5
        [Authorize(Roles = "Sale")]
        public ActionResult Delete(int? id)
        {
            ViewBag.image = Session["account_image"];
            ViewBag.id = Session["account_id"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shipping shipping = db.shippings.Find(id);
            if (shipping == null)
            {
                return HttpNotFound();
            }
            return View("Delete", shipping);
        }

        // POST: shippings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                shipping shipping = db.shippings.Find(id);
                db.shippings.Remove(shipping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "The shiper has been in use so you can not delete them");
                shipping shipping = db.shippings.Find(id);
                return View("Delete", shipping);
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
