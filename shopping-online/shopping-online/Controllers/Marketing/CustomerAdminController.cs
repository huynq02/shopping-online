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
        [Authorize(Roles = "Admin, Marketing")]

        public ActionResult Index(string search, int page=1, int pageSize=5)
        {
            if (Session["account_id"] != null)
            {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                var role = db.Roles.Where(x => x.Role_name == "Customer").FirstOrDefault();
                //var cus = db.Accounts.OrderByDescending(x => x.account_role_id == role.Role_id).ToPagedList(page, pageSize);
                var cus = db.Accounts.Where(x => x.account_role_id == role.Role_id).OrderByDescending(x => x.account_createdate).ToPagedList(page, pageSize);
                if (search != null)
                {
                    cus = db.Accounts.Where(x => x.account_name.Contains(search) && x.account_role_id == role.Role_id).OrderByDescending(x => x.account_createdate).ToPagedList(page, pageSize);
                }
                CustomerModel customer = new CustomerModel();
                customer.account = cus;
                customer.search = search;
                return View(customer);

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }
    }
}