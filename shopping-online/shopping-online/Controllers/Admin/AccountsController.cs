using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using shopping_online.Context;
using shopping_online.Models;

namespace shopping_online.Controllers.Admin
{
    public class AccountsController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLogin model)
        {
            
                bool IsValidUser = db.Accounts.Any(user => user.account_username.ToLower() ==
                     model.account_username.ToLower() && user.account_password == model.account_password);
                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.account_username, false);
                    return RedirectToAction("Index", "PageProduct");
                }
                ModelState.AddModelError("", "invalid Username or Password");
                return View();
          
        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Account model)
        {
           
            bool IsValidUser = db.Accounts.Any(user => user.account_username.ToLower() ==
                     model.account_username.ToLower());
            if (IsValidUser == false)
            {
                model.account_role_id = 2;
                model.account_status = true;
                db.Accounts.Add(model);
                db.SaveChanges();

                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "invalid Username or Password");
            return View();

           
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        // GET: Accounts
        public ActionResult Index()
        {
            var accounts = db.Accounts.Include(a => a.Role);
            return View(accounts.ToList());
        }


        // GET: Accounts/Create
        public ActionResult Create()
        {
            ViewBag.account_role_id = new SelectList(db.Roles, "Role_id", "Role_name");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "account_id,account_username,account_password,account_email,account_name,account_phone,account_address,account_role_id,account_gender,account_status,account_createdate")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.account_role_id = new SelectList(db.Roles, "Role_id", "Role_name", account.account_role_id);
            return View(account);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
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

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "account_id,account_username,account_password,account_email,account_name,account_phone,account_address,account_role_id,account_gender,account_status,account_createdate")] Account account)
        {
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
        public ActionResult Delete(int? id)
        {
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

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Account account = db.Accounts.Find(id);
                db.Accounts.Remove(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
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
