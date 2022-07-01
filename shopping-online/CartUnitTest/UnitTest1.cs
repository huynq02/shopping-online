using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using shopping_online.Context;
using shopping_online.Controllers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;


namespace CartUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddToCart()
        {
            var obj = new CartController();
            var expect = "Index";
            RedidectToRouteResult result = obj.AddItem(new CartController()
            {

            })
        }
    }
}
