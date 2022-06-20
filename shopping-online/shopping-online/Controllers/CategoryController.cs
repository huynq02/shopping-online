using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var listProductByCategory = objCategory.Products.Where(n => n.category_id == Id).ToList();
            var listC = objCategory.Categories.ToList();
            var listColor = objCategory.Colors.ToList();
            var listImage = objCategory.Image_product.ToList();
            ProductByCategory p1 = new ProductByCategory();
            p1.listProductByCate = listProductByCategory;
            p1.listC = listC;
            p1.listColor = listColor;
            p1.listI = listImage;
            return View(p1);
        }
    }
}