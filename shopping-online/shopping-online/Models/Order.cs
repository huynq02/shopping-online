using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
<<<<<<<< HEAD:shopping-online/shopping-online/Models/EditBlog.cs
    public class EditBlog
    {
        public Blog blog { get; set; }
========
    public class Order
    {
        public int OrderID { get; set; } 

        public string NameOrder { get; set; }
>>>>>>>> main:shopping-online/shopping-online/Models/Order.cs
    }
}