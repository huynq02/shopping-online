using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace shopping_online.Controllers.Admin
{

    public class LoginController : Controller
    {
        // GET: Login

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
            int count = GetRole(model.account_username.ToLower());
          


           
            var a = getUserId(model.account_username);



            var usersecsion = new UserLogin();
            usersecsion.account_id = model.account_id;
            if (IsValidUser)
            {
                if (count == 1)
                {
                    FormsAuthentication.SetAuthCookie(model.account_username, false);
                    return RedirectToAction("Index", "ListHome");
                }
                else if (count == 2)
                {
                    FormsAuthentication.SetAuthCookie(model.account_username, false);
                    return RedirectToAction("Index", "Accounts");
                }
                else if (count == 3)
                {
                    FormsAuthentication.SetAuthCookie(model.account_username, false);
                    return RedirectToAction("Index", "Admin");
                }
                else if (count == 4)
                {
                    FormsAuthentication.SetAuthCookie(model.account_username, false);
                    return RedirectToAction("Index", "shippings");
                }
                else { return View(); }


            }
            ModelState.AddModelError("", "invalid Username or Password");
            return View();

        }
        public Account getUserId(string username)
        {
            return db.Accounts.SingleOrDefault(user => user.account_username.ToLower() ==
                    username.ToLower());
        }
        private int GetRole(string username)
        {
            int role = (from user in db.Accounts
                        join roles in db.Roles
                        on user.account_role_id equals roles.Role_id
                        where user.account_username.ToLower() == username.ToLower()
                        select roles.Role_id).SingleOrDefault();
            return role;
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Account model, string gender)
        {

            bool IsValidUser = db.Accounts.Any(user => user.account_username.ToLower() ==
                     model.account_username.ToLower());
            if (IsValidUser == false)
            {
                if (gender == "Male")
                {
                    model.account_gender = true;
                }
                else
                {
                    model.account_gender = false;
                }
                model.account_status = true;
                model.account_role_id = 1;
                model.account_createdate = DateTime.Today;

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

        [HttpPost]
        public JsonResult uploadFile(HttpPostedFileBase uploadedFiles)
        {
            string returnImagePath = string.Empty;
            string fileName;
            string Extension;
            string imageName;
            string imageSavePath;

            if (uploadedFiles.ContentLength > 0)
            {
                fileName = System.IO.Path.GetFileNameWithoutExtension(uploadedFiles.FileName);
                Extension = System.IO.Path.GetExtension(uploadedFiles.FileName);
                imageName = fileName + DateTime.Now.ToString("yyyyMMddHHmmss");
                imageSavePath = Server.MapPath("/Content/images/") + imageName + Extension;

                uploadedFiles.SaveAs(imageSavePath);
                returnImagePath = "/Content/images/" + imageName + Extension;
            }
            return Json(Convert.ToString(returnImagePath), JsonRequestBehavior.AllowGet);
        }


        [OutputCache(Duration = int.MaxValue, VaryByParam = "id")]
        public ActionResult ProfileOfAdmin(int? id)
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

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProfileAdmin([Bind(Include = "account_id,account_username,account_password,account_email,account_name,account_phone,account_address,account_role_id,account_gender,account_status,account_createdate")] Account account)
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
        public ActionResult ProfileUser(int? id)
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

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProfileUser([Bind(Include = "account_id,account_username,account_password,account_email,account_name,account_phone,account_address,account_role_id,account_gender,account_status,account_createdate")] Account account)
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

    }

}