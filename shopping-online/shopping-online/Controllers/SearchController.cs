using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using shopping_online.Context;
using shopping_online.Models;

namespace shopping_online.Controllers
{
    public class SearchController : Controller
    {
        DBContext db = new DBContext();
        // GET: Search
        public ActionResult Index(string search, int page = 1, int pageSize = 1)
        {
            var lstBlog = db.Blogs.Where(x => x.blog_title.Contains("A")).OrderByDescending(x => x.blog_createdate).ToPagedList(page, pageSize);
            var lstPro = db.products.Where(x => x.product_name.Contains("A")).OrderByDescending(x => x.product_name).ToPagedList(page, pageSize);
            SearchModel searchs = new SearchModel();
            searchs.lstBlog = lstBlog;
            searchs.lstPro = lstPro;
            return View(search);
        }
    }
}