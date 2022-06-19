
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using shopping_online.Models;

namespace shopping_online.Controllers
{
    public class LoginController : Controller
    {
        Project_SU22Entities db = new Project_SU22Entities();
        // GET: Login
        public ActionResult Index()
        {
            if (Session["account_id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        //GET: Register

        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Account acc)
        {
            if (ModelState.IsValid)
            {
                var check = db.Accounts.FirstOrDefault(s => s.account_email == acc.account_email);
                if (check == null)
                {
                    acc.account_password = GetMD5(acc.account_password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Accounts.Add(acc);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();

        }
        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var account_password = GetMD5(password);
                var data = db.Accounts.Where(s => s.account_email.Equals(email) && s.account_password.Equals(account_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().account_username + " " + data.FirstOrDefault().account_name;
                    Session["account_email"] = data.FirstOrDefault().account_email;
                    Session["account_id"] = data.FirstOrDefault().account_id;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }


        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}