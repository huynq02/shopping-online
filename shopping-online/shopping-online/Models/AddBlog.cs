using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class AddBlog
    {
        //
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Descriptions { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string Image { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string Detail { get; set; }
    }
}