using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers.User
{
    public class UserAdminController : Controller
    {
        DBContext db = new DBContext();
        // GET: UserAdmin
        public ActionResult Index()
        {
            ViewBag.Id = Session["account_id"];
            int Id = ViewBag.Id;
            var user = db.Accounts.FirstOrDefault(x => x.account_id == Id);
            var lstOrder = db.Orders.Where(x => x.account_id == Id).ToList();
            var lstODetail = db.Order_Details.ToList();
            var product = db.products.ToList();
            UserAdmin userAdmin = new UserAdmin();
            userAdmin.lstOde = lstODetail;
            userAdmin.lstOder = lstOrder;
            userAdmin.lstPro = product;
            return View(userAdmin);
        }

        public ActionResult ToPay()
        {
            return View();
        }

        public ActionResult ToReceive()
        {
            return View();
        }

        public ActionResult ToShip()
        {
            return View();
        }

        public ActionResult Completed()
        {
            return View();
        }

        public ActionResult Cancelled()
        {
            return View();
        }
    }
}