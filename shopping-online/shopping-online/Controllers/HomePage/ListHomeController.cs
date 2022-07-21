using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace shopping_online.Controllers.HomePage
{
   
    public class ListHomeController : Controller
    {
        private DBContext obj = new DBContext();
        // GET: ListHome
        public ActionResult Index(string search ,int page = 1, int pageSize = 9)
        {

            ViewBag.image = Session["account_image"];
            ViewBag.id = Session["account_id"];
            var listProduct = obj.products.OrderByDescending(x => x.product_id).ToPagedList(page, pageSize);
                    if (!String.IsNullOrEmpty(search))
                    {
                        listProduct = obj.products.OrderByDescending(x => x.product_id).Where(n => n.product_name.Contains(search)).ToPagedList(page, pageSize);
                    }
                    var listCategory = obj.Categories.ToList();
                    var listColor = obj.Colors.ToList();
                    var listSlide = obj.Slides.ToList();
                    ListHome List = new ListHome();
                    List.listColor = listColor;
                    List.listProduct = listProduct;
                    List.listCategory = listCategory;
                    List.listSlide = listSlide;
                    return View("Index", List);
           
              

          
            

            //var listProduct = obj.Products.OrderByDescending(x => x.product_id).ToPagedList(page, pageSize);
           
        }
        //public ActionResult Search(string search)
        //{
        //    var lstProduct = obj.products.Where(n => n.product_name.Contains(search)).ToList();
        //    ListHome ListS = new ListHome();
        //    ListS.ListSearchProduct = lstProduct;
        //    return View("Index",ListS);

        //}
    }
}