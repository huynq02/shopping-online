using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopping_online.Controllers;
using shopping_online.Models;
using System.Data.SqlClient;

namespace shopping_online.Controllers
{
    public class AccountController : Controller
    {
        //public ActionResult Index() {
        //    return View();
        //}
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        //POST: Hàm Register (Post) Nhân dữ liệu từ trang đăng kí và thực hiên tạo mới dữ liệu
        [HttpPost]
        public ActionResult Register(FormCollection collection, Account Acc)
        {
            //Gán giá trị người dùng  nhập dữ liệu các biến
            var username = collection["UserName"];
            var pasword = collection ["password"];
            var 
        return Register();
        }  
    }
}