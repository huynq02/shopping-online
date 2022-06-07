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
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectionString() 
        {
            con.ConnectionString = "data source= ADMIN-PC\SQLSERVERHUY; database=Project_SU22_lan3_TuanAnh; intergrated security = SSPI; ";
        }
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select* from Account where account_name";
            return View();
        //    if (Dr.Read());
        //    {
        //        return View();
        //    }
        //    else 
        //    {
        //        return View();
        //    }
        //    con.Close();
        //}

    }
}