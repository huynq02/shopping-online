using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Models
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //public ActionResult Index(int page = 1, int pageSize = 9)
            //{
            //    var listProduct = obj.Products.OrderByDescending(x => x.product_id).ToPagedList(page, pageSize);
            //    var listCategory = obj.Categories.ToList();
            //    var listColor = obj.Colors.ToList();
            //    ListHome List = new ListHome();
            //    List.listColor = listColor;
            //    List.listProduct = listProduct;
            //    List.listCategory = listCategory;
            //    return View(List);
            //}
        }
    }
}