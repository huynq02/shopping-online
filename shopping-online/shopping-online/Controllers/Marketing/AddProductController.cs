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
        DBContext db = new DBContext();
        // GET: AddProduct
        [Authorize(Roles = "Admin,  Marketing")]
        public ActionResult Index()
        {
           
                if (Session["account_id"] != null)
                {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                    var lstColor = db.Colors.ToList();
                    var lstCategory = db.Categories.ToList();
                    var lstStatus = db.status_product.ToList();
                    Add_Product addPro = new Add_Product();
                    addPro.lstColor = lstColor;
                    addPro.lstCategories = lstCategory;
                    addPro.lstStatus = lstStatus;
                    return View(addPro);
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            
            
        }
        [Authorize(Roles = " Marketing")]

        [HttpPost]
        public ActionResult Create(product pro, string ProductCode, string ProductName, Decimal ProductPrice, int ProductQuanity, string Description,
                                   string ImageProduct, int ColorID, int CategoryID, int StatusID, string CreateDate, string Back_Link)
        {

            if (Session["account_id"] != null)
            {

                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                pro.product_code = ProductCode;
                pro.product_name = ProductName;
                pro.product_description = Description;
                pro.product_price = ProductPrice;
                pro.product_quantity = ProductQuanity;
                pro.product_image = ImageProduct;
                pro.color_id = ColorID;
                pro.category_id = CategoryID;
                pro.status_product_id = StatusID;
                pro.product_backlink = Back_Link;
                pro.product_create_date = DateTime.ParseExact(CreateDate, "yyyy-MM-dd", null);
                db.products.Add(pro);
                db.SaveChanges();
                return RedirectToAction("Index", "ProductAdmin");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

           
        }
    }
}