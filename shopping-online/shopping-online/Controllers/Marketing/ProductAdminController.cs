using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using shopping_online.Models;

namespace shopping_online.Controllers.Marketing
{
    public class ProductAdminController : Controller
    {
        // GET: ProductAdmin
        DBContext db = new DBContext();
        [Authorize(Roles = "Admin, Sale, Marketing")]

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
        [Authorize(Roles = " Marketing")]

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
        [Authorize(Roles = "Marketing")]

        public ActionResult Delete(int Id)
        {
            product pro = db.products.Where(x => x.product_id == Id).FirstOrDefault();
            db.products.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("Index", "ProductAdmin");
        }
    }
}