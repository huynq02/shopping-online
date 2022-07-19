using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers.Sale
{
    public class DashboardSaleController : Controller
    {
        // GET: DashboardSale
        public ActionResult Index()
        {
            if (Session["account_id"] != null)
            {
                ViewBag.id = Session["account_id"];
               
                return View();

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

    }
}