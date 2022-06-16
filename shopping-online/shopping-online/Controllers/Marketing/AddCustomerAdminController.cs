using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            account.Account_status = true;
            account.account_role = 1;
            db.Accounts.Add(account);
            db.SaveChanges();
            return RedirectToAction("Index", "CustomerAdmin");
        }

        public ActionResult AccountNeedEdit(int Id)
        {
            var customer = db.Accounts.Where(x => x.account_id == Id).FirstOrDefault();
            CustomerModel cus = new CustomerModel();
            cus.acc = customer;
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
                acc.Account_status = true;
            } else
            {
                acc.Account_status = false;
            }
            acc.account_id = Id;
            db.Entry(acc).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "CustomerAdmin");
        }

        public ActionResult UnLockAccount(int Id)
        {
            Account account = db.Accounts.Where(x => x.account_id == Id).FirstOrDefault();
            account.Account_status = true;
            db.Entry(account).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "CustomerAdmin");
        }

        public ActionResult LockAccount(int Id)
        {
            Account account = db.Accounts.Where(x => x.account_id == Id).FirstOrDefault();
            account.Account_status = false;
            db.Entry(account).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "CustomerAdmin");
        }
    }
}