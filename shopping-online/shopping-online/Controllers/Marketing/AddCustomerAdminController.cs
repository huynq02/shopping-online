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
        [Authorize(Roles = "Admin, Marketing")]
        public ActionResult Index()
        {
           
                if (Session["account_id"] != null)
                {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            
          
        }
        [Authorize(Roles = " Marketing")]

        public ActionResult Create(Account account, string gender, string CreateDate, string Account_password)
        {
            if (Session["account_id"] != null)
            {

                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                if (gender == "Male")
                {
                    account.account_gender = true;
                }
                account.account_status = true;
                account.account_role_id = 1;
                account.account_password = Account_password;
                account.account_createdate = DateTime.ParseExact(CreateDate, "yyyy-MM-dd", null);
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index", "CustomerAdmin");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

           
        }
        [Authorize(Roles = " Marketing")]

        public ActionResult AccountNeedEdit(int Id, int page = 1, int pageSize = 5)
        {
            if (Session["account_id"] != null)
            {

                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                var customer = db.Accounts.Where(x => x.account_id == Id).FirstOrDefault();
                var orderCustomer = db.Orders.Where(x => x.account_id == Id).ToList();
                var orderCus = db.Orders.Where(x => x.account_id == Id).FirstOrDefault();
                List<Order_Details> orderDetailCus = null;
                if (orderCus != null)
                {
                    orderDetailCus = db.Order_Details.Where(x => x.Order_id == orderCus.Order_id).ToList();
                }
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
            else
            {
                return RedirectToAction("Login", "Login");
            }

          
        }
        [Authorize(Roles = " Marketing")]

        public ActionResult Edit(Account acc, int Id, string gender, string status)
        {
            
                if (Session["account_id"] != null)
                {

                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                var role = db.Roles.Where(x => x.Role_name == "Customer").FirstOrDefault();
                var accold = db.Accounts.Where(x => x.account_id == Id).FirstOrDefault();
                if (gender == "Male")
                {
                    acc.account_gender = true;
                }
                else
                {
                    acc.account_gender = false;
                }
                if (status == "Active")
                {
                    acc.account_status = true;
                    UnLockAccount(Id);
                }
                else
                {
                    acc.account_status = false;
                    LockAccount(Id);
                }
                acc.account_id = Id;
                acc.account_role_id = role.Role_id;
                //db.Entry(acc).State = EntityState.Modified;
                db.Entry(accold).CurrentValues.SetValues(acc);
                db.SaveChanges();
                return RedirectToAction("Index", "CustomerAdmin");
            }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            
           
        }
        [Authorize(Roles = " Marketing")]

        public ActionResult UnLockAccount(int Id)
        {
            ViewBag.image = Session["account_image"];
            ViewBag.id = Session["account_id"];
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

            new MailHelper().SendMail("phuongnthe151412@fpt.edu.vn", "Thông báo", content);
            return RedirectToAction("Index", "CustomerAdmin");
        }

        [Authorize(Roles = " Marketing")]
        public ActionResult LockAccount(int Id)
        {
            if (Session["account_id"] != null)
            {

                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
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

                new MailHelper().SendMail("phuongnthe151412@fpt.edu.vn", "Thông báo", content);
                new MailHelper().SendMail(toEmail, "Thông báo", content);
                return RedirectToAction("Index", "CustomerAdmin");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }
    }
}