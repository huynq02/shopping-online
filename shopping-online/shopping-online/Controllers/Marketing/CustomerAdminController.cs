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
        Project_SU22Entities db = new Project_SU22Entities();
        // GET: CustomerAdmin
        public ActionResult Index(int page=1, int pageSize=5)
        {
            var role = db.Roles.Where(x => x.role_name == "Customer").FirstOrDefault();
            var cus = db.Accounts.OrderByDescending(x => x.account_role == role.id).ToPagedList(page, pageSize);
            CustomerModel customer = new CustomerModel();
            customer.account = cus;
            return View(customer);
        }
    }
}