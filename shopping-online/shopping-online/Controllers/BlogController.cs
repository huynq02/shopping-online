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
        Project_SU22Entities db = new Project_SU22Entities();
        // GET: Blog
        public ActionResult Index(int page = 1, int pageSize = 1)
        {
            var blog = db.Blogs.OrderByDescending(x => x.createdate).ToPagedList(page, pageSize);
            var cate = db.Categories.ToList();
            var color = db.Colors.ToList();
            BlogModel bg = new BlogModel();
            bg.blog = blog;
            bg.cate = cate;
            bg.color = color;
            return View(bg);
        }
    }
}