using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers.Accounts
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(shopping_online.Context.Account accountModel)
        {
            using (DBContext db = new DBContext())
            {
                var accountDetails = db.Accounts.Where(x => x.account_username == accountModel.account_username && x.account_password == accountModel.account_password).FirstOrDefault();
                if (accountDetails == null)
                {
                    accountModel.LoginErrorMessage = "Wrong username or password.";
                    return View("Index", accountModel);
                }
                else
                {
                    Session["userID"] = accountDetails.account_id;
                    Session["userName"] = accountDetails.account_username;
                    return RedirectToAction("Index", "shippings");
                }
            }
        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
