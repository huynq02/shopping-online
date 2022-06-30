using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using shopping_online.Controllers.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace shopping_online.Controllers.Sale.Tests
{
    [TestClass()]
    public class Order_statusControllerTests
    {
        [TestMethod()]
        public void correct_create_Order_status()
        {
            Order_statusController obj = new Order_statusController();

            var expect = "Create";
            ViewResult result = obj.Create() as ViewResult;

            NUnit.Framework.Assert.That(result.ViewName, Is.EqualTo(expect));

        }
    }
}