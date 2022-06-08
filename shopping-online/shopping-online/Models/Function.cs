using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class Function
    {
        public int function_id { get; set; }
        public string function_name { get; set; }
        public string function_description { get; set; }
        public int function_ordernumber { get; set; }
        public DateTime function_createday { get; set; }
    }
}