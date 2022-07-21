using PagedList;
using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers.Marketing
{
    public class BlogAdminController : Controller
    {
        DBContext db = new DBContext();
        // GET: BlogAdmin
        [Authorize(Roles = "Admin, Marketing")]
        public ActionResult Index(string search, int page = 1, int pageSize = 5)
        {

            if (Session["account_id"] != null)
            {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                var blog = db.Blogs.OrderByDescending(x => x.blog_createdate).ToPagedList(page, pageSize);
                if (search != null)
                {
                    blog = db.Blogs.Where(x => x.blog_title.Contains(search)).OrderByDescending(x => x.blog_createdate).ToPagedList(page, pageSize);
                }
                BlogModel bg = new BlogModel();
                bg.blog = blog;
                bg.search = search;
                return View(bg);

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
           
        }
    }
}