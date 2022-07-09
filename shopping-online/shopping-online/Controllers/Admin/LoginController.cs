using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace shopping_online.Controllers.Admin
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(AccountLogin account)
        {

            //var userdetails = db.Accounts.Where(x => x.account_username == account.account_username && x.account_password == account.account_password).FirstOrDefault();
            //if(userdetails == null)
            //{
            //    return RedirectToAction("Login", "Login");

            //}
            //else
            //{
            //    Session["user"] = userdetails.account_username;
            //    return RedirectToAction("Index", "shippings");
            //}
            using (DBContext db = new DBContext())
            {
                bool IsValidUser = db.Accounts.Any(user => user.account_username.ToLower() ==
                           account.account_username.ToLower() && user.account_password == account.account_password);

                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(account.account_username, false);
                    return RedirectToAction("Login", "Login");
                }

                ModelState.AddModelError("", "invalid Username or Password");
                return View();
            }

        }
    }
}