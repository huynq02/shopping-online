using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopping_online.Models;

namespace shopping_online.Controllers
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
        public ActionResult Autherize(shopping_online.Models.Account accModel)
        {
            using (Project_SU22Entities db = new Project_SU22Entities())
            {
                var accDetails = db.Account.Where(x => x.UserName == accModel.UserName && x.Password == accModel.Password).FirstOrDefault();
                if (accDetails == null)
                {
                    accModel.LoginErrorMessage = "Wrong username or password.";
                    return View("Index", accModel);
                }
                else
                {
                    Session["account_id"] = accDetails.UserID;
                    Session["account_username"] = accDetails.UserName;
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["account_id"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}