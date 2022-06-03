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
        Project_SU22Entities db = new Project_SU22Entities();
        // GET: BlogDetail
        public ActionResult Index(int Id)
        {
            var blog = db.Blogs.Where(x => x.id == Id).FirstOrDefault();
            BlogModel bg = new BlogModel();
            bg.bg = blog;
            return View(bg);
        }
    }
}