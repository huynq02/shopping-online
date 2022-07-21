using PagedList;
using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers
{
    public class BlogController : Controller
    {
        DBContext db = new DBContext();
        // GET: Blog
        public ActionResult Index(int page = 1, int pageSize = 4)
        {
            ViewBag.image = Session["account_image"];
            ViewBag.id = Session["account_id"];
            var blog = db.Blogs.OrderByDescending(x => x.blog_createdate).ToPagedList(page, pageSize);
            var cate = db.Categories.ToList();
            var color = db.Colors.ToList();
            var pro = db.products.ToList();
            BlogModel bg = new BlogModel();
            bg.blog = blog;
            bg.cate = cate;
            bg.color = color;
            bg.ListProducts = pro;
            return View(bg);
        }
    }
}