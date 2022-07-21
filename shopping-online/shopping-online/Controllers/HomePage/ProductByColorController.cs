using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers.HomePage
{
    public class ProductByColorController : Controller
    {
        private DBContext objColor = new DBContext();
        // GET: ProductByColor
        public ActionResult Index(int id)
        {

            ViewBag.image = Session["account_image"];
            ViewBag.id = Session["account_id"];
            var listProductByColor = objColor.products.Where(n => n.color_id == id).ToList();
                var listC = objColor.Categories.ToList();
                var listColor = objColor.Colors.ToList();
                //var listImage = objColor.Image_product.ToList();
                var listP = objColor.products.ToList();
                ProductByColor p2 = new ProductByColor();
                p2.listC = listC;
                p2.listColor = listColor;
                //p2.listI = listImage;
                p2.ListProductByColor = listProductByColor;
                p2.listP = listP;
                return View("Index", p2);
                
            }
    }
}