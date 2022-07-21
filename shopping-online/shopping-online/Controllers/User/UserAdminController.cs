using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            ViewBag.image = Session["account_image"];
            int Id = ViewBag.Id;
            var user = db.Accounts.FirstOrDefault(x => x.account_id == Id);
            var lstOrder = db.Orders.Where(x => x.account_id == Id).ToList();
            var lstODetail = db.Order_Details.ToList();
            var product = db.products.ToList();
            var lstOSta = db.Order_status.ToList();
            UserAdmin userAdmin = new UserAdmin();
            userAdmin.lstOde = lstODetail;
            userAdmin.lstOder = lstOrder;
            userAdmin.lstPro = product;
            userAdmin.lstOSta = lstOSta;
            return View(userAdmin);
            
           
        }


        public ActionResult ToPay()
        {
            ViewBag.Id = Session["account_id"];
            ViewBag.image = Session["account_image"];
            int Id = ViewBag.Id;
            var status = db.Order_status.Where(x => x.Order_status_status == "Chờ xác nhận").FirstOrDefault();
            var lstOrder = db.Orders.Where(x => x.account_id == Id && x.Order_status_id == status.Order_status_id).ToList();
            var lstODetail = db.Order_Details.ToList();
            var product = db.products.ToList();
            UserAdmin userAdmin = new UserAdmin();
            userAdmin.lstOde = lstODetail;
            userAdmin.lstOder = lstOrder;
            userAdmin.lstPro = product;
            return View(userAdmin);
        }

        public ActionResult ToReceive()
        {
            ViewBag.Id = Session["account_id"];
            ViewBag.image = Session["account_image"];
            int Id = ViewBag.Id;
            var status = db.Order_status.Where(x => x.Order_status_status == "Đang giao").FirstOrDefault();
            var lstOrder = db.Orders.Where(x => x.account_id == Id && x.Order_status_id == status.Order_status_id).ToList();
            var lstODetail = db.Order_Details.ToList();
            var product = db.products.ToList();
            UserAdmin userAdmin = new UserAdmin();
            userAdmin.lstOde = lstODetail;
            userAdmin.lstOder = lstOrder;
            userAdmin.lstPro = product;
            return View(userAdmin);
            return View();
        }

        public ActionResult ToShip()
        {
            ViewBag.Id = Session["account_id"];
            ViewBag.image = Session["account_image"];
            int Id = ViewBag.Id;
            var status = db.Order_status.Where(x => x.Order_status_status == "Chờ lấy hàng").FirstOrDefault();
            var lstOrder = db.Orders.Where(x => x.account_id == Id && x.Order_status_id == status.Order_status_id).ToList();
            var lstODetail = db.Order_Details.ToList();
            var product = db.products.ToList();
            UserAdmin userAdmin = new UserAdmin();
            userAdmin.lstOde = lstODetail;
            userAdmin.lstOder = lstOrder;
            userAdmin.lstPro = product;
            return View(userAdmin);
         
        }

        public ActionResult Completed()
        {
            ViewBag.Id = Session["account_id"];
            ViewBag.image = Session["account_image"];
            int Id = ViewBag.Id;
            var status = db.Order_status.Where(x => x.Order_status_status == "Đã giao hàng").FirstOrDefault();
            var lstOrder = db.Orders.Where(x => x.account_id == Id && x.Order_status_id == status.Order_status_id).ToList();
            var lstODetail = db.Order_Details.ToList();
            var product = db.products.ToList();
            UserAdmin userAdmin = new UserAdmin();
            userAdmin.lstOde = lstODetail;
            userAdmin.lstOder = lstOrder;
            userAdmin.lstPro = product;
            return View(userAdmin);
        }

        public ActionResult Cancelled()
        {
            ViewBag.Id = Session["account_id"];
            ViewBag.image = Session["account_image"];
            int Id = ViewBag.Id;
            var status = db.Order_status.Where(x => x.Order_status_status == "Hủy đơn hàng").FirstOrDefault();
            var lstOrder = db.Orders.Where(x => x.account_id == Id && x.Order_status_id == status.Order_status_id).ToList();
            var lstODetail = db.Order_Details.ToList();
            var product = db.products.ToList();
            UserAdmin userAdmin = new UserAdmin();
            userAdmin.lstOde = lstODetail;
            userAdmin.lstOder = lstOrder;
            userAdmin.lstPro = product;
            return View(userAdmin);
        }

        public ActionResult Cancel(int Id)
        {
            ViewBag.image = Session["account_image"];
            ViewBag.Id = Session["account_id"];
            var status = db.Order_status.FirstOrDefault(x => x.Order_status_status == "Hủy đơn hàng");
            var order = db.Orders.Where(x => x.Order_id == Id).FirstOrDefault();
            order.Order_status_id = status.Order_status_id;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}