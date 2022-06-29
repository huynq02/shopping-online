using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shopping_online.Context;

namespace shopping_online.Controllers.Admin
{
    public class Role_functionController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Role_function
        public ActionResult Index()
        {
            var role_function = db.Role_function.Include(r => r.Function).Include(r => r.Role);
            return View(role_function.ToList());
        }

        // GET: Role_function/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role_function role_function = db.Role_function.Find(id);
            if (role_function == null)
            {
                return HttpNotFound();
            }
            return View(role_function);
        }

        // GET: Role_function/Create
        public ActionResult Create()
        {
            ViewBag.function_id = new SelectList(db.Functions, "function_id", "function_name");
            ViewBag.role_id = new SelectList(db.Roles, "Role_id", "Role_name");
            return View();
        }

        // POST: Role_function/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Role_function_id,function_id,role_id,Role_function_view,Role_function_insert,Role_function_update,Role_function_delete")] Role_function role_function)
        {
            if (ModelState.IsValid)
            {
                db.Role_function.Add(role_function);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.function_id = new SelectList(db.Functions, "function_id", "function_name", role_function.function_id);
            ViewBag.role_id = new SelectList(db.Roles, "Role_id", "Role_name", role_function.role_id);
            return View(role_function);
        }

        // GET: Role_function/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role_function role_function = db.Role_function.Find(id);
            if (role_function == null)
            {
                return HttpNotFound();
            }
            ViewBag.function_id = new SelectList(db.Functions, "function_id", "function_name", role_function.function_id);
            ViewBag.role_id = new SelectList(db.Roles, "Role_id", "Role_name", role_function.role_id);
            return View(role_function);
        }

        // POST: Role_function/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Role_function_id,function_id,role_id,Role_function_view,Role_function_insert,Role_function_update,Role_function_delete")] Role_function role_function)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role_function).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.function_id = new SelectList(db.Functions, "function_id", "function_name", role_function.function_id);
            ViewBag.role_id = new SelectList(db.Roles, "Role_id", "Role_name", role_function.role_id);
            return View(role_function);
        }

        // GET: Role_function/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role_function role_function = db.Role_function.Find(id);
            if (role_function == null)
            {
                return HttpNotFound();
            }
            return View(role_function);
        }

        // POST: Role_function/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Role_function role_function = db.Role_function.Find(id);
            db.Role_function.Remove(role_function);
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
