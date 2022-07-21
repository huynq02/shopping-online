using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers.HomePage
{
    public class AboutUsController : Controller
    {
        private DBContext obj = new DBContext();
        // GET: AboutUs
        public ActionResult Index()
        {
            ViewBag.image = Session["account_image"];
            ViewBag.id = Session["account_id"];
            var product = obj.products.ToList();
            BlogModel bg = new BlogModel();
            bg.ListProducts = product;
            return View(bg);
        }
    }
}