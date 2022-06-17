using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace shopping_online.Controllers.Marketing
{
    public class AddCustomerAdminController : Controller
    {
        Project_SU22Entities db = new Project_SU22Entities();
        // GET: AddCustomerAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create (Account account, string gender)
        {
            if (gender == "Male")
            {
                account.account_gender = true;
            }
            account.account_status= true;
            account.account_role = 1;
            db.Accounts.Add(account);
            db.SaveChanges();
            return RedirectToAction("Index", "CustomerAdmin");
        }

        public ActionResult AccountNeedEdit(int Id, int page = 1, int pageSize = 5)
        {
            var customer = db.Accounts.Where(x => x.account_id == Id).FirstOrDefault();
            var orderCustomer = db.Orders.Where(x => x.account_id == Id).ToList();
            var orderCus = db.Orders.Where(x => x.account_id == Id).FirstOrDefault();
            var orderDetailCus = db.Order_Details.Where(x => x.Order_id == orderCus.Order_id).ToList();
            var product = db.products.ToList();
            var orderSta = db.Order_status.ToList();
            CustomerModel cus = new CustomerModel();
            cus.acc = customer;
            cus.lstOrder = orderCustomer;
            cus.product = product;
            cus.lstOrderCus = orderDetailCus;
            cus.lstOrderStatus = orderSta;
            return View(cus);
        }

        public ActionResult Edit(Account acc, int Id, string gender, string status)
        {
            if (gender == "Male")
            {
                acc.account_gender = true;
            } else
            {
                acc.account_gender = false;
            }
            if (status == "Active")
            {
                acc.account_status = true;
            } else
            {
                acc.account_status = false;
            }
            acc.account_id = Id;
            db.Entry(acc).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "CustomerAdmin");
        }

        public ActionResult UnLockAccount(int Id)
        {
            Account account = db.Accounts.Where(x => x.account_id == Id).FirstOrDefault();
            account.account_status = true;
            db.Entry(account).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "CustomerAdmin");
        }

        public ActionResult LockAccount(int Id)
        {
            Account account = db.Accounts.Where(x => x.account_id == Id).FirstOrDefault();
            account.account_status = false;
            db.Entry(account).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "CustomerAdmin");
        }
    }
}