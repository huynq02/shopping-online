using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers.Marketing
{
    public class AdminController : Controller
    {
        DBContext db = new DBContext();
        // GET: Admin
        [Authorize(Roles = "Admin, Sale, Marketing")]
        public ActionResult Index()
        {
            if (Session["account_id"] != null)
            {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                var lstProduct = db.products.ToList();
                var cus = db.Roles.Where(x => x.Role_name == "Customer").FirstOrDefault();
                var lstCustomer = db.Accounts.Where(x => x.account_role_id == cus.Role_id).ToList();
                var lstBlog = db.Blogs.ToList();
                var order = db.Orders.ToList();

                var blog = db.Blogs.Where(x => EntityFunctions.TruncateTime(x.blog_createdate) == EntityFunctions.TruncateTime(DateTime.Now)).FirstOrDefault();
                var proCreate = db.products.Where(x => EntityFunctions.TruncateTime(x.product_create_date) == EntityFunctions.TruncateTime(DateTime.Now)).FirstOrDefault();
                var cusCreate = db.Accounts.Where(x => EntityFunctions.TruncateTime(x.account_createdate) == EntityFunctions.TruncateTime(DateTime.Now)).FirstOrDefault();
                var slideCreate = db.Slides.Where(x => EntityFunctions.TruncateTime(x.slide_createdate) == EntityFunctions.TruncateTime(DateTime.Now)).FirstOrDefault();
                //Take the product have the same datetime.nox to show the notification
                var orderDate = db.Orders.Where(x => EntityFunctions.TruncateTime(x.Order_Date) == EntityFunctions.TruncateTime(DateTime.Now)).ToList();
                var orderDetail = db.Order_Details.ToList();
                List<Order_Details> orderDe = new List<Order_Details>();
                foreach (var i in orderDate)
                {
                    foreach (var j in orderDetail)
                    {
                        if (i.Order_id == j.Order_id)
                        {
                            orderDe.Add(j);
                        }
                    }
                }
                List<product> lstProOder = new List<product>();
                foreach (var i in orderDe)
                {
                    foreach (var j in lstProduct)
                    {
                        if (i.product_id == j.product_id)
                        {
                            lstProOder.Add(j);
                        }
                    }
                }
                //Product out of stock
                var lstProOut = db.products.Where(x => x.product_quantity == 0).ToList();

                // Take a Slide, Product, Slide edit
                //Take a Blog, Product, Slide delete

                double sum = 0;
                foreach (var item in order)
                {
                    sum += item.Order_total_money;
                }
                HomeAdmin homeadmin = new HomeAdmin();
                homeadmin.lstBlog = lstBlog;
                homeadmin.lstCustomer = lstCustomer;
                homeadmin.lstProduct = lstProduct;
                homeadmin.blog = blog;
                homeadmin.cusCreate = cusCreate;
                homeadmin.proCreate = proCreate;
                homeadmin.slideCreate = slideCreate;
                homeadmin.lstProOder = lstProOder;
                homeadmin.lstProOut = lstProOut;
                //homeadmin.editSlide = editSliede;
                homeadmin.sum = sum;
                return View(homeadmin);

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

           
        }
    }
}