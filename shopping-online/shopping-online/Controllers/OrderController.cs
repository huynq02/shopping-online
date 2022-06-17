using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using shopping_online.Models;



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
            int pageSize = 10;
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
        public ActionResult Details(int id)
        {
          
            Order order = db.Orders.FirstOrDefault(x => x.Order_id == id);
            Order_Details orderdetails = db.Order_Details.FirstOrDefault(x => x.Order_id == id);
           
            
            if (order == null&& orderdetails == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(orderdetails);
        }
        [HttpPost]
   
       public ActionResult Create()
        {
            return View();
        }
    }
}