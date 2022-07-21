using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PagedList;
using shopping_online.Context;
using shopping_online.Models;

namespace shopping_online.Controllers.Admin
{

    public class AccountsController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Accounts
        [Authorize(Roles = "Admin")]
        public ActionResult Index(string table_search, int? page)
        {
            ViewBag.image = Session["account_image"];
            ViewBag.id = Session["account_id"];
            int padeNum = (page ?? 1);
            int pageSize = 20;

            List<Account> accounts = db.Accounts.ToList();
            IQueryable<Account> acc = db.Accounts;
            IQueryable<Role> roles = db.Roles;
            if (!string.IsNullOrEmpty(table_search))
            {
                acc = acc.Where(x => x.account_name.Contains(table_search) || x.account_username.Contains(table_search)
                || x.account_email.Contains(table_search) || x.account_phone.Contains(table_search));
                roles = roles.Where(x => x.Role_name.Contains(table_search));
            }
            var pto = acc.OrderBy(x => x.account_createdate).ToPagedList(padeNum, pageSize);
            ViewBag.table_search = table_search;
            return View("Index", pto);
        }


        // GET: Accounts/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.image = Session["account_image"];
            ViewBag.id = Session["account_id"];
            ViewBag.account_role_id = new SelectList(db.Roles, "Role_id", "Role_name");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "account_id,account_username,account_password,account_email,account_name,account_phone,account_address,account_role_id,account_gender,account_status,account_createdate")] Account account)
        {
            if (ModelState.IsValid)
            {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.account_role_id = new SelectList(db.Roles, "Role_id", "Role_name", account.account_role_id);
            return View(account);
        }

        // GET: Accounts/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            ViewBag.image = Session["account_image"];
            ViewBag.id = Session["account_id"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.account_role_id = new SelectList(db.Roles, "Role_id", "Role_name", account.account_role_id);
            return View(account);
        }
        [Authorize(Roles = "Admin")]
        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "account_id,account_username,account_password,account_email,account_name,account_phone,account_address,account_role_id,account_gender,account_status,account_createdate")] Account account)
        {
            ViewBag.image = Session["account_image"];
            ViewBag.id = Session["account_id"];
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.account_role_id = new SelectList(db.Roles, "Role_id", "Role_name", account.account_role_id);
            return View(account);
        }

        // GET: Accounts/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            ViewBag.image = Session["account_image"];
            ViewBag.id = Session["account_id"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }
        [Authorize(Roles = "Admin")]
        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                int Id = ViewBag.id;
                Account account = db.Accounts.Find(id);
                bool IsValidUserActive = db.Accounts.Any(user => user.account_id == Id && user.account_status == true);
                if (IsValidUserActive == false)
                {

                    db.Accounts.Remove(account);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                   ModelState.AddModelError("", "Account can to delete because they are active");
                    return View();
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Account can to delete because they are active ");
                return View();
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
