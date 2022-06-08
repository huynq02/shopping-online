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
}