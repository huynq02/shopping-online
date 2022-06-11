using PagedList;
using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class CustomerModel
    {
        //New Comment
        public Account acc { get; set; }
        public IPagedList<Account> account { get; set; }
        public Role role { get; set; }
    }
}