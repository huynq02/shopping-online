﻿using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
            bool IsValidUserActive = db.Accounts.Any(user => user.account_username.ToLower() ==
                 model.account_username.ToLower() && user.account_password == model.account_password && user.account_status == true);

            Session["account_username"] = "";
            if (IsValidUser)
            {
                if (IsValidUserActive)
                {
                    int count = GetRole(model.account_username.ToLower());
                    int id = GetID(model.account_username.ToLower());
                    if (count == 1)
                    {
                        // 1 customer
                        FormsAuthentication.SetAuthCookie(model.account_username, false);
                        Session["account_username"] = model.account_username;
                        Session["account_id"] = id;
                        return RedirectToAction("Index", "ListHome");
                    }
                    else if (count == 2)
                    {
                        //admin
                        FormsAuthentication.SetAuthCookie(model.account_username, false);
                        Session["account_username"] = model.account_username;
                        Session["account_id"] = id;
                        return RedirectToAction("Index", "Accounts");
                    }

                    else if (count == 3)
                    {
                        // marketing
                        FormsAuthentication.SetAuthCookie(model.account_username, false);
                        Session["account_username"] = model.account_username;
                        Session["account_id"] = id;
                        return RedirectToAction("Index", "ProductAdmin");
                    }
                    else if (count == 4)
                    {
                        //sale
                        FormsAuthentication.SetAuthCookie(model.account_username, false);
                        Session["account_username"] = model.account_username;
                        Session["account_id"] = id;
                        return RedirectToAction("Index", "shippings");
                    }
                    else { return View(); }
                }
                else
                {
                    ModelState.AddModelError("", "Your account has been ban");
                    return View();
                }
            }
            ModelState.AddModelError("", "invalid Username or Password");
            return View();

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

        private int GetID(string username)
        {
            int id = (from user in db.Accounts
                      where user.account_username.ToLower() == username.ToLower()
                      select user.account_id).SingleOrDefault();
            return id;
        }

        [HttpPost]
        public JsonResult IsUserNameAvailable(string UserName)
        {
            return Json(!db.Accounts.Any(x => x.account_username == UserName),
                                                 JsonRequestBehavior.AllowGet);
        }
        public ActionResult Signup()
        {

            return View();
        }

        private string getImage(int id)
        {
            string image = (from user in db.Accounts
                            where user.account_id == id
                            select user.account_image).SingleOrDefault();
            return image;
        }

        [HttpPost]
        public ActionResult Signup(Account model, string gender, string phone)
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

                model.account_image = "http://ssl.gstatic.com/accounts/ui/avatar_2x.png";

                db.Accounts.Add(model);
                db.SaveChanges();

                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "invalid Username or Password");
            return View();


        }

        [HttpPost]
        public ActionResult UploadFiles(HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Method 2 Get file details from HttpPostedFileBase class    

                    if (file != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/UploadedFiles"), Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                    }
                    ViewBag.FileStatus = "File uploaded successfully.";
                }
                catch (Exception)
                {
                    ViewBag.FileStatus = "Error while file uploading."; ;
                }
            }
            return View("Index");
        }




        //[Authorize(Roles = "Admin, Sale, Customer, Marketing")]
        [HttpGet]
        public ActionResult profile(int? id)
        {
            if (ViewBag.account_image == null)
            {

                ViewBag.account_image = "http://ssl.gstatic.com/accounts/ui/avatar_2x.png";
            }
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
            Account acc = db.Accounts.Where(a => a.account_id == id).FirstOrDefault();
            ViewBag.account_image = acc.account_image;
            return View("profile", account);
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



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult profile([Bind(Include = "account_id,account_username,account_password,account_email,account_name,account_phone,account_address,account_role_id,account_gender,account_status, account_image,account_createdate")] Account account, HttpPostedFileBase account_image)
        {
            if (ViewBag.account_image == null)
            {

                ViewBag.account_image = "http://ssl.gstatic.com/accounts/ui/avatar_2x.png";
            }
            ViewBag.id = Session["account_id"];
            if (ModelState.IsValid)
            {
                if (account_image != null)
                {
                    string a = Path.GetFileName(account_image.FileName);
                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"), Path.GetFileName(account_image.FileName));
                    account_image.SaveAs(path);
                    account.account_image = account_image.FileName;
                   
                }

                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.account_image = account.account_image;
                return View("profile", account);
            }
            ViewBag.account_role_id = new SelectList(db.Roles, "Role_id", "Role_name", account.account_role_id);
            return View("profile", account);
        }

        public ActionResult profileAdmin(int? id)
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
            ViewBag.account_image = account.account_image;
            return View(account);
        }
        //[Authorize(Roles = "Admin, Sale, Customer, Marketing")]
        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult profileAdmin([Bind(Include = "account_id,account_username,account_password,account_email,account_name,account_phone,account_address,account_role_id,account_gender,account_status,account_createdate")] Account account, string account_image)
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
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }

}