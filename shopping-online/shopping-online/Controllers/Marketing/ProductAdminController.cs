using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using shopping_online.Models;
using System.Data.Entity;
using System.Globalization;

namespace shopping_online.Controllers.Marketing
{
    public class ProductAdminController : Controller
    {
        // GET: ProductAdmin
        DBContext db = new DBContext();
        public ActionResult Index(string search, int page=1, int pageSize=5)
        {
            
            var lstProduct = db.products.OrderByDescending(x => x.product_create_date).ToPagedList(page, pageSize);
            if (search != null)
            {
                lstProduct = db.products.Where(x => x.product_name.Contains(search)).OrderByDescending(x => x.product_create_date).ToPagedList(page, pageSize);
            }
            var color = db.Colors.ToList();
            var stapro = db.status_product.ToList();
            ProductModel product = new ProductModel();
            product.lstProduct = lstProduct;
            product.color = color;
            product.stapro = stapro;
            product.search = search;
            return View(product);
        }

        public ActionResult Edit(int Id)
        {
            var product = db.products.Where(x => x.product_id == Id).FirstOrDefault();
            var color = db.Colors.ToList();
            var stapro = db.status_product.ToList();
            var cate = db.Categories.ToList();
            ProductModel pro = new ProductModel();
            pro.product = product;
            pro.color = color;
            pro.stapro = stapro;
            pro.lstCategories = cate;
            return View(pro);
        }

        public ActionResult SaveEdit(product product, int Id, string ProductCode, string ProductName, Decimal ProductPrice, int ProductQuanity, string Description,
                                   string Img, int ColorID, int CategoryID, int StatusID, string CreateDate, string Back_Link)
        {
            var pro = db.products.Where(x => x.product_id == Id).FirstOrDefault();
            pro.product_code = ProductCode;
            pro.product_code = ProductCode;
            pro.product_name = ProductName;
            pro.product_description = Description;
            pro.product_price = ProductPrice;
            pro.product_quantity = ProductQuanity;
            pro.product_image = Img;
            pro.color_id = ColorID;
            pro.category_id = CategoryID;
            pro.status_product_id = StatusID;
            pro.product_backlink = Back_Link;
            pro.product_create_date = DateTime.ParseExact(CreateDate, "yyyy-MM-dd", null);
            db.Entry(pro).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            product pro = db.products.Where(x => x.product_id == Id).FirstOrDefault();
            db.products.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("Index", "ProductAdmin");
        }
    }
}