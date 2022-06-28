using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers
{
    public class ProductByColorController : Controller
    {

        Project_SU22Entities objColor = new Project_SU22Entities();
        // GET: ProductByColor
        public ActionResult Index(int id)
        {
            var listProductByColor = objColor.Products.Where(n => n.color_id == id).ToList();
            var listC = objColor.Categories.ToList();
            var listColor = objColor.Colors.ToList();
            //var listImage = objColor.Image_product.ToList();
            var listP = objColor.Products.ToList();
            ProductByColor p2 = new ProductByColor();
            p2.listC = listC;
            p2.listColor = listColor;
            //p2.listI = listImage;
            p2.ListProductByColor = listProductByColor;
            p2.listP = listP;
            return View(p2);
        }
    }
}