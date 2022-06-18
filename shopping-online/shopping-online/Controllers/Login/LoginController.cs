using shopping_online.Models;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace shopping_online.Controllers.Login
{
    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source = ADMIN; database=Project_SU22; integrated security=true;";
        }
        [HttpPost]
        public ActionResult verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Account ";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                //return View(""Error"");
            }
        }
    }
}