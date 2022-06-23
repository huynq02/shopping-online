using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers
{
    public class PageProductController : Controller
    {
        Project_SU22Entities obj = new Project_SU22Entities();
        // GET: PageProduct
        public ActionResult Index(int page = 1, int pageSize = 15)
        {
            var listProduct = obj.Products.OrderByDescending(x => x.product_id).ToPagedList(page, pageSize);
            var listColors = obj.Colors.ToList();
            var listCategory = obj.Categories.ToList();
            PageProduct productDetail = new PageProduct();
            productDetail.listCategory = listCategory;
            productDetail.listColor = listColors;
            productDetail.listProduct = listProduct;
            return View(productDetail);
        }
    }
}