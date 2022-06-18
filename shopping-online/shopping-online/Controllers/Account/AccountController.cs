using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers.Login
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            if (Session["account_id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }   
    }
}