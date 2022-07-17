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
        [Authorize(Roles = "Sale")]

        public ActionResult Index()
        {
            return View();
        }
    }
}