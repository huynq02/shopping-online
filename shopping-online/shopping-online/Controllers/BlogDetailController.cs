using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers
{
    public class BlogDetailController : Controller
    {
        DBContext db = new DBContext();
        // GET: BlogDetail
        public ActionResult Index(int Id)
        {
            ViewBag.image = Session["account_image"];
            ViewBag.id = Session["account_id"];
            var blog = db.Blogs.Where(x => x.blog_id == Id).FirstOrDefault();
            var relateBlog = db.Blogs.Where(x => x.blog_id == Id - 1).FirstOrDefault();
            if (Id == 1)
            {
                relateBlog = db.Blogs.Where(x => x.blog_id == Id + 1).FirstOrDefault();
            }
            var cate = db.Categories.ToList();
            var color = db.Colors.ToList();
            var pro = db.products.ToList();

            BlogModel bg = new BlogModel();
            bg.bg = blog;
            bg.relateBlog = relateBlog;
            bg.cate = cate;
            bg.color = color;
            bg.ListProducts = pro;
            return View(bg);
        }
    }
}