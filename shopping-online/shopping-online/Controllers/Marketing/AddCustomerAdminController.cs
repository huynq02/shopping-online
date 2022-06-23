using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Configuration;
using shopping_online.Common;

namespace shopping_online.Controllers.Marketing
{
    public class AddCustomerAdminController : Controller
    {
        DBContext db = new DBContext();
        // GET: AddCustomerAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create (Account account, string gender, string createDate, string password)
        {
            if (gender == "Male")
            {
                account.account_gender = true;
            }
            account.account_status= true;
            account.account_role_id = 1;
            account.account_password = password;
            account.account_createdate = DateTime.ParseExact(createDate, "yyyy-MM-dd", null);
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
                UnLockAccount(Id);
            } else
            {
                acc.account_status = false;
                LockAccount(Id);
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
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/template/HtmlPage1.html"));
            //content = content.Replace("{{CustomerName}}", shipName);
            //content = content.Replace("{{Phone}}", mobile);
            //content = content.Replace("{{Email}}", email);
            //content = content.Replace("{{Address}}", address);
            //content = content.Replace("{{Total}}", total.ToString("N0"));
            var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

            // Để Gmail cho phép SmtpClient kết nối đến server SMTP của nó với xác thực 
            //là tài khoản gmail của bạn, bạn cần thiết lập tài khoản email của bạn như sau:
            //Vào địa chỉ https://myaccount.google.com/security  Ở menu trái chọn mục Bảo mật, sau đó tại mục Quyền truy cập 
            //của ứng dụng kém an toàn phải ở chế độ bật
            //  Đồng thời tài khoản Gmail cũng cần bật IMAP
            //Truy cập địa chỉ https://mail.google.com/mail/#settings/fwdandpop

            new MailHelper().SendMail("tuananh462001@gmail.com", "Thông báo", content);
            return RedirectToAction("Index", "CustomerAdmin");
        }

        public ActionResult LockAccount(int Id)
        {
            Account account = db.Accounts.Where(x => x.account_id == Id).FirstOrDefault();
            account.account_status = false;
            db.Entry(account).State = EntityState.Modified;
            db.SaveChanges();
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/template/notification.html"));
            //content = content.Replace("{{CustomerName}}", shipName);
            //content = content.Replace("{{Phone}}", mobile);
            //content = content.Replace("{{Email}}", email);
            //content = content.Replace("{{Address}}", address);
            //content = content.Replace("{{Total}}", total.ToString("N0"));
            var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

            // Để Gmail cho phép SmtpClient kết nối đến server SMTP của nó với xác thực 
            //là tài khoản gmail của bạn, bạn cần thiết lập tài khoản email của bạn như sau:
            //Vào địa chỉ https://myaccount.google.com/security  Ở menu trái chọn mục Bảo mật, sau đó tại mục Quyền truy cập 
            //của ứng dụng kém an toàn phải ở chế độ bật
            //  Đồng thời tài khoản Gmail cũng cần bật IMAP
            //Truy cập địa chỉ https://mail.google.com/mail/#settings/fwdandpop

            new MailHelper().SendMail("tuananh462001@gmail.com", "Thông báo", content);
            new MailHelper().SendMail(toEmail, "Thông báo", content);
            return RedirectToAction("Index", "CustomerAdmin");
        }
    }
}