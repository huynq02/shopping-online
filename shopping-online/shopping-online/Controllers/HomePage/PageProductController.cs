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
    public class PageProductController : Controller
    {
        private DBContext obj = new DBContext();
        // GET: PageProduct
        public ActionResult Index(int page = 1, int pageSize = 15)
        {

            ViewBag.image = Session["account_image"];
            ViewBag.id = Session["account_id"];
            var listProduct = obj.products.OrderByDescending(x => x.product_id).ToPagedList(page, pageSize);
                var listColors = obj.Colors.ToList();
                var listCategory = obj.Categories.ToList();
                PageProduct productDetail = new PageProduct();
                productDetail.listCategory = listCategory;
                productDetail.listColor = listColors;
                productDetail.listProduct = listProduct;
                return View("Index", productDetail);
           

        }
       
    }
}