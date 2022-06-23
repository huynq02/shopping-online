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
        public ActionResult Index()
        {
            var lstProduct = db.products.ToList();
            var cus = db.Roles.Where(x => x.Role_name == "Customer").FirstOrDefault();
            var lstCustomer = db.Accounts.Where(x => x.account_role_id == cus.Role_id).ToList();
            var lstBlog = db.Blogs.ToList();
            var order = db.Orders.ToList();
            
            var blog = db.Blogs.Where(x => EntityFunctions.TruncateTime(x.blog_createdate) == EntityFunctions.TruncateTime(DateTime.Now)).FirstOrDefault();
            var proCreate = db.products.Where(x => EntityFunctions.TruncateTime(x.product_create_date) == EntityFunctions.TruncateTime(DateTime.Now)).FirstOrDefault();
            var cusCreate = db.Accounts.Where(x => EntityFunctions.TruncateTime(x.account_createdate) == EntityFunctions.TruncateTime(DateTime.Now)).FirstOrDefault();
            var slideCreate = db.Slides.Where(x => EntityFunctions.TruncateTime(x.slide_createdate) == EntityFunctions.TruncateTime(DateTime.Now)).FirstOrDefault();
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
            homeadmin.sum = sum;
            return View(homeadmin);
        }
    }
}