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
        private int id = 0;
        public ActionResult Index(string search, string result = "product", int page = 1, int pageSize = 3)
        {
            //if (id == 0)
            //{
            //    result = "product";
            //} else
            //{
            //}
            //id++;
            //IPagedList<product> lstPro = null;
            //IPagedList<Blog> lstBlog = null;
            //if (result == "product")
            //{
            //    lstPro = db.products.Where(x => x.product_name.Contains(search)).OrderByDescending(x => x.product_name).ToPagedList(page, pageSize);
            //}
            //if (result == "blog")
            //{
            //    lstBlog = db.Blogs.Where(x => x.blog_title.Contains(search)).OrderByDescending(x => x.blog_createdate).ToPagedList(page, pageSize);
            //}
            ViewBag.image = Session["account_image"];
            ViewBag.id = Session["account_id"];
            var lstPro = db.products.Where(x => x.product_name.Contains(search)).OrderByDescending(x => x.product_name).ToPagedList(page, pageSize);
            var lstBlog = db.Blogs.Where(x => x.blog_title.Contains(search)).OrderByDescending(x => x.blog_createdate).ToPagedList(page, pageSize);
            var product = db.products.ToList();
            SearchModel searchs = new SearchModel();
            searchs.lstBlog = lstBlog;
            searchs.lstPro = lstPro;
            searchs.search = search;
            searchs.result = result;
            searchs.ListProduct = product;
            return View(searchs);
        }
    }
}
