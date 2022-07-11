using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using shopping_online.Context;


namespace shopping_online.Models
{
    [Serializable]
    public class CartItem
    {

        public product product { set; get; }
        public int Quantity { set; get; }

    }
}