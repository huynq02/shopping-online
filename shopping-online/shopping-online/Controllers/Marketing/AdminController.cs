using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers.Marketing
{
    public class AdminController : Controller
    {
        Project_SU22Entities db = new Project_SU22Entities();
        // GET: Admin
        public ActionResult Index()
        {
            var lstProduct = db.Products.ToList();
            var cus = db.Roles.Where(x => x.role_name == "Customer").FirstOrDefault();
            var lstCustomer = db.Accounts.Where(x => x.account_role == cus.id).ToList();
            var lstBlog = db.Blogs.ToList();
            var blog = db.Blogs.Where(x => x.createdate == DateTime.Now).FirstOrDefault();
                        
            HomeAdmin homeadmin = new HomeAdmin();
            homeadmin.lstBlog = lstBlog;
            homeadmin.lstCustomer = lstCustomer;
            homeadmin.lstProduct = lstProduct;
            homeadmin.blog = blog;
            return View(homeadmin);
        }
    }
}