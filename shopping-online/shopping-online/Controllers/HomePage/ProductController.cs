using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers.HomePage
{
    public class ProductController : Controller
    {
        private DBContext obj = new DBContext();
        // GET: Product
        public ActionResult Index(int Id)
        {



            ViewBag.image = Session["account_image"];
            ViewBag.id = Session["account_id"];
            var objProduct = obj.products.Where(n => n.product_id == Id).FirstOrDefault();
                //var objImg = obj.Image_product.Where(x => x.id == objProduct.image_id).FirstOrDefault();
                var listCategory = obj.Categories.ToList();
                var listColor = obj.Colors.ToList();
                var listProduct = obj.products.ToList();
                var listSize = obj.sizes.ToList();
                ProductDetail productDetail = new ProductDetail();
                productDetail.objProduct = objProduct;
                //productDetail.objImage = objImg;
                productDetail.lstCategory = listCategory;
                productDetail.lstColor = listColor;
                productDetail.lstProduct = listProduct;
                productDetail.lstSize = listSize;
                return View("Index", productDetail);
           
        }
    }
}