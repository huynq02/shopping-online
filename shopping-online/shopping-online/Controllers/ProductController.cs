using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var objProduct = obj.Products.Where(n => n.product_id == Id).FirstOrDefault();
            var objImg = obj.Image_product.Where(x => x.id == objProduct.image_id).FirstOrDefault();
            var listCategory = obj.Categories.ToList();
            var listColor = obj.Colors.ToList();
            ProductDetail productDetail = new ProductDetail();
            productDetail.objProduct = objProduct;
            productDetail.objImage = objImg;
            productDetail.lstCategory = listCategory;
            productDetail.lstColor = listColor;

            return View(productDetail);
        }
    }
}