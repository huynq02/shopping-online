using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class AddCustomer
    {
        public string Account_username { get; set; }
        public string Account_email { get; set; }
        public string Account_password { get; set; }
        public string Account_name { get; set; }
        public string Account_phone { get; set; }
        public string Account_address { get; set; }
        public bool Account_gender { get; set; }
        public bool Account_status { get; set; }
        public DateTime CreateDate { get; set; }

    }
}