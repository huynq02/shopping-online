using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class AddSlide
    {
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string Imageslide { get; set; }
        public string Descriptions { get; set; }
        public bool Status_Id { get; set; }
    }
}