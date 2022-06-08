﻿using PagedList;
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
        Project_SU22Entities db = new Project_SU22Entities();
        // GET: BlogAdmin
        public ActionResult Index(int page = 1, int pageSize = 1)
        {
            var blog = db.Blogs.OrderByDescending(x => x.createdate).ToPagedList(page, pageSize);
            BlogModel bg = new BlogModel();
            bg.blog = blog;
            return View(bg);
        }
    }
}