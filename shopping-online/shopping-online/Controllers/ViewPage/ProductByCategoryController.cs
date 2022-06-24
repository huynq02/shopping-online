using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers.ViewPage
{
    public class ProductByCategoryController : Controller
    {
        DBContext objCategory = new DBContext();
        // GET: Category
        public ActionResult Index(int Id)
        {
            var listProductByCategory = objCategory.products.Where(n => n.category_id == Id).ToList();
            var listC = objCategory.Categories.ToList();
            var listColor = objCategory.Colors.ToList();
            //var listImage = objCategory..ToList();
            var listP = objCategory.products.ToList();
            ProductByCategory p1 = new ProductByCategory();
            p1.listProductByCate = listProductByCategory;
            p1.listC = listC;
            p1.listColor = listColor;
            //p1.listI = listImage;
            p1.listP = listP;
            return View(p1);
        }
    }
}