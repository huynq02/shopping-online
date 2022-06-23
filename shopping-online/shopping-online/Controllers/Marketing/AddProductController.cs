using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers.Marketing
{
    public class AddProductController : Controller
    {
        Project_SU22Entities db = new Project_SU22Entities();
        // GET: AddProduct
        public ActionResult Index()
        {
            var lstColor = db.Colors.ToList();
            var lstCategory = db.Categories.ToList();
            var lstStatus = db.status_product.ToList();
            Add_Product addPro = new Add_Product();
            addPro.lstColor = lstColor;
            addPro.lstCategories = lstCategory;
            addPro.lstStatus = lstStatus;
            return View(addPro);
        }
        public ActionResult Create(product pro, string code, string name, double price, int quantity, string image, int color, int category, int status, string createDate)
        {
            pro.product_code = code;
            pro.product_name = name;
            pro.product_price = price;
            pro.product_quantity = quantity;
            pro.image_product = image;
            pro.color_id = color;
            pro.category_id = category;
            pro.status_product_id = status;
            pro.product_create_date = DateTime.ParseExact(createDate, "yyyy-MM-dd", null);
            db.products.Add(pro);
            db.SaveChanges();
            return RedirectToAction("Index", "ProductAdmin");
        }
    }
}