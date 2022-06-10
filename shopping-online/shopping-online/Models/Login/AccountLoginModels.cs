using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class Account
    {
        public int account_id { get; set; }
        public string account_username { get; set; }
        public string account_password { get; set; }
        public string account_email { get; set; } 
        public string account_phone { get; set; }
        public string account_adress { get; set; }
        public int account_role_id { get; set; }
        public bool account_gender { get; set; }
        public DateTime account_DOB { get; set; }
    }
    public class Function
    {
        public int function_id { get; set; }
        public string function_name { get; set; }
        public string function_description { get; set; }
        public int function_ordernumber { get; set; }
        public DateTime function_createday { get; set; }
    }
    public class Role_function
    {
        public string Role_function_id { get; set; }
        public string function_id { get; set; }
        public string role_id { get; set; }
        public string Role_function_view { get; set; }
        public string Role_function_insert { get; set; }
        public string Role_function_update { get; set; }
        public string Role_function_delete { get; set; }

    }
    public class Role
    {
        public int Role_id { get; set; }
        public string Role_name { get; set; }
        public string Role_description { get; set; }
    }
}