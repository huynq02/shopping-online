using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using shopping_online.Models;
using shopping_online.Context;
using System.Configuration;
using shopping_online.Common;

namespace shopping_online.Controllers
{
    public class CartController : Controller
    {
        DBContext db = new DBContext();
        private int productId;
        private const string CartSession = "CartSession";
        // GET: Cart

        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.product.product_id == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.product.product_id == item.product.product_id);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public ActionResult AddItem(int productId, int quantity)
        {
            var product = db.products.FirstOrDefault(c => c.product_id == productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.product.product_id == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.product.product_id == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]

        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(string shipName, string mobile, string address, string email)
        {
            var account = new Account();
            var order = new Order();
            order.Order_Date = DateTime.Now;
            account.account_address = address;
            account.account_phone = mobile;
            account.account_name = shipName;
            account.account_email = email;

            try
            {

                //Thêm Order               
                db.Orders.Add(order);
                db.SaveChanges();
                var id = order.Order_id;

                var cart = (List<CartItem>)Session[CartSession];

                decimal total = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new Order_Details();
                    orderDetail.product_id = item.product.product_id;
                    orderDetail.Order_Details_id = id;
                    orderDetail.Order_Details_price = item.product.product_price;
                    orderDetail.Order_Details_num = item.Quantity;
                    db.Order_Details.Add(orderDetail);
                    db.SaveChanges();
                    //total += (item.product.product_price * item.Quantity);
                    product product = db.products.Where(x => x.product_id == orderDetail.product_id).FirstOrDefault();
                    product.product_quantity = (int)(product.product_quantity - orderDetail.Order_Details_num);
                    total += (item.product.product_price * item.Quantity);
                }
                string content = System.IO.File.ReadAllText(Server.MapPath("~/content/template/neworder.html"));

                content = content.Replace("{{CustomerName}}", shipName);
                content = content.Replace("{{Phone}}", mobile);
                content = content.Replace("{{Email}}", email);
                content = content.Replace("{{Total}}", total.ToString("N0"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                // Để Gmail cho phép SmtpClient kết nối đến server SMTP của nó với xác thực 
                //là tài khoản gmail của bạn, bạn cần thiết lập tài khoản email của bạn như sau:
                //Vào địa chỉ https://myaccount.google.com/security  Ở menu trái chọn mục Bảo mật, sau đó tại mục Quyền truy cập 
                //của ứng dụng kém an toàn phải ở chế độ bật
                //  Đồng thời tài khoản Gmail cũng cần bật IMAP
                //Truy cập địa chỉ https://mail.google.com/mail/#settings/fwdandpop

                new MailHelper().SendMail(email, "Đơn hàng mới từ Cửa hàng", content);
                new MailHelper().SendMail(toEmail, "Đơn hàng mới từ Cửa hàng", content);
                //Xóa hết giỏ hàng
                Session[CartSession] = null;
            }
            catch (Exception)
            {
                //ghi log
                return Redirect("/Cart/Unsuccess");
            }
            return Redirect("/Cart/Success");
        }

        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Unsuccess()
        {
            return View();
        }
    }
}