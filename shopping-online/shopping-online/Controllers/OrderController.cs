using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using shopping_online.Models;
using System.Data;
using System.IO;


namespace shopping_online.Controllers
{
    public class OrderController : Controller
    {
        DBContext db = new DBContext();
        // GET: Sale
        public class InstructorIndexData
        {
            public PagedList.IPagedList<Order> Shipping { get; set; }

        }
        public ActionResult Orders(string table_search, int? page)
        {
            int padeNum = (page ?? 1);
            int pageSize = 20;
            List<Order> orders = db.Orders.ToList();
            IQueryable<Order> od = db.Orders;
            IQueryable<Order_Details> ords = db.Order_Details;
            IQueryable<Account> accounts = db.Accounts;
           
            if (!string.IsNullOrEmpty(table_search))
            {
                od = od.Where(x => x.Order_note.Contains(table_search));
                accounts = accounts.Where(x => x.account_username.Contains(table_search));
            }
            var pto = od.OrderBy(x=> x.Order_Date).ToPagedList(padeNum, pageSize);
            ViewBag.table_search = table_search;
            return View(pto);

        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
        if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var order = db.Orders.Find(id);
            if(order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
        [HttpPost]
   
       public ActionResult Create()
        {
            return View();
        }
    }
}