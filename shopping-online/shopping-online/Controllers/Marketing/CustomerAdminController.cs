using PagedList;
using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers.Marketing
{
    public class CustomerAdminController : Controller
    {
        DBContext db = new DBContext();
        // GET: CustomerAdmin
        public ActionResult Index(int page=1, int pageSize=5)
        {
            var role = db.Roles.Where(x => x.Role_name == "Customer").FirstOrDefault();
            var cus = db.Accounts.OrderByDescending(x => x.account_role_id == role.Role_id).ToPagedList(page, pageSize);
            CustomerModel customer = new CustomerModel();
            customer.account = cus;
            return View(customer);
        }
    }
}