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
            bool IsValidUserActive = db.Accounts.Any(user => user.account_username.ToLower() ==
                 model.account_username.ToLower() && user.account_password == model.account_password && user.account_status == true);

            if (IsValidUser)
            {
                if (IsValidUserActive) {
                int count = GetRole(model.account_username.ToLower());
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
                    return RedirectToAction("Index", "shippings");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(model.account_username, false);
                    return RedirectToAction("Index", "Blog");
                }
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
                else{
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
    }
    
}