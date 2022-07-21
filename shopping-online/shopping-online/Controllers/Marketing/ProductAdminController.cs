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
        [Authorize(Roles = "Admin, Marketing")]
        

        public ActionResult Index(string search, int page=1, int pageSize=5)
        {
            if (Session["account_id"] != null)
            {
                ViewBag.id = Session["account_id"];

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
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }
        [Authorize(Roles = " Marketing")]

        public ActionResult Edit(int Id)
        {
            if (Session["account_id"] != null)
            {
                ViewBag.id = Session["account_id"];

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
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }
        [Authorize(Roles = " Marketing")]

        public ActionResult SaveEdit(product product, int Id, string Img, int ColorID, int CategoryID, int StatusID)
        {
            if (Session["account_id"] != null)
            {
                ViewBag.id = Session["account_id"];
                ViewBag.image = Session["account_image"];
                var pro = db.products.Where(x => x.product_id == Id).FirstOrDefault();
                //Console.WriteLine(pro);
                pro.product_code = product.product_code;
                pro.product_name = product.product_name;
                pro.product_description = product.product_description;
                pro.product_image = Img;
                pro.status_product_id = StatusID;
                pro.category_id = CategoryID;
                pro.color_id = ColorID;
                pro.product_quantity = product.product_quantity;
                pro.product_price = product.product_price;
                pro.product_backlink = product.product_backlink;
                pro.product_create_date = product.product_create_date;
                //db.Entry(pro).State = EntityState.Modified;
                db.Entry<product>(pro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
           
        }
        [Authorize(Roles = " Marketing")]

        public ActionResult Delete(int Id)
        {
            if (Session["account_id"] != null)
            {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"]; 
                product pro = db.products.Where(x => x.product_id == Id).FirstOrDefault();
                db.products.Remove(pro);
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