using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using shopping_online.Context;
using shopping_online.Controllers.Sale;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {

        //[TestMethod()]
        //public void createorder()
        //{
        //    var obj = new Order_statusController();
        //    var expect = "Index";
        //    RedirectToRouteResult result = obj.Create(new Order_status()
        //    {

        //        Order_status_status = "D1"

        //    }) as RedirectToRouteResult;
        //    NUnit.Framework.Assert.That(result.RouteValues["action"], Is.EqualTo(expect));


        //}
        [TestMethod()]
        public void TestDepartmentCreateErrorView()
        {
            var obj = new Order_statusController();
            var expect = "Index";
            ViewResult result = obj.Create(new Order_status()
            {

                Order_status_status = ""
            }) as ViewResult;

            NUnit.Framework.Assert.That(result.ViewName, Is.EqualTo("Create"));
        }
        [TestMethod()]
        public void IndexOrder()
        {
            OrderController obj = new OrderController();

            var actResult = obj.Index("a", 1) as ViewResult;

            NUnit.Framework.Assert.IsNotNull(actResult);

        }
        [TestMethod()]
        public void IndexSale()
        {
            SaleController obj = new SaleController();

            var actResult = obj.Index() as ViewResult;

            NUnit.Framework.Assert.IsNotNull(actResult);

        }
        [TestMethod()]
        public void IndexShip()
        {
            shippingsController obj = new shippingsController();

            var actResult = obj.Index("a", 1) as ViewResult;

            NUnit.Framework.Assert.IsNotNull(actResult);

        }
        [TestMethod()]
        public void IndexOrderstatus()
        {
            Order_statusController obj = new Order_statusController();

            var actResult = obj.Index() as ViewResult;

            NUnit.Framework.Assert.IsNotNull(actResult);

        }
        [TestMethod()]
        public void correct_Index_Order_status()
        {
            Order_statusController obj = new Order_statusController();

            var expect = "Index";


            var actResult = obj.Index() as ViewResult;
            var a = actResult.ViewName;

            NUnit.Framework.Assert.That(a, Is.EqualTo(expect));

        }
        [TestMethod()]
        public void correct_Index_Order()
        {
            OrderController obj = new OrderController();

            var expect = "Index";


            var actResult = obj.Index("a", 1) as ViewResult;
            var a = actResult.ViewName;

            NUnit.Framework.Assert.That(a, Is.EqualTo(expect));

        }
        [TestMethod()]
        public void correct_Index_Ship()
        {
            shippingsController obj = new shippingsController();

            var expect = "Index";


            var actResult = obj.Index("a", 1) as ViewResult;
            var a = actResult.ViewName;

            NUnit.Framework.Assert.That(a, Is.EqualTo(expect));

        }
        [TestMethod()]
        public void correct_Index_Sale()
        {
            SaleController obj = new SaleController();

            var expect = "Index";


            var actResult = obj.Index() as ViewResult;
            var a = actResult.ViewName;

            NUnit.Framework.Assert.That(a, Is.EqualTo(expect));

        }

        [TestMethod()]
        public void correct_create_Order()
        {
            OrderController obj = new OrderController();

            var expect = "Create";
            ViewResult result = obj.Create() as ViewResult;

            NUnit.Framework.Assert.That(result.ViewName, Is.EqualTo(expect));

        }
        [TestMethod()]
        public void correct_create_Order_status()
        {
            Order_statusController obj = new Order_statusController();

            var expect = "Create";
            ViewResult result = obj.Create() as ViewResult;

            NUnit.Framework.Assert.That(result.ViewName, Is.EqualTo(expect));

        }
        [TestMethod()]
        public void correct_create_ship()
        {
            shippingsController obj = new shippingsController();

            var expect = "Create";
            ViewResult result = obj.Create() as ViewResult;

            NUnit.Framework.Assert.That(result.ViewName, Is.EqualTo(expect));

        }
        [TestMethod()]
        public void correct_edit_ship()
        {
            shippingsController obj = new shippingsController();

            var expect = "Edit";
            ViewResult result = obj.Edit(3) as ViewResult;

            NUnit.Framework.Assert.That(result.ViewName, Is.EqualTo(expect));

        }
        [TestMethod()]
        public void correct_edit_order()
        {
            OrderController obj = new OrderController();

            var expect = "Edit";
            ViewResult result = obj.Edit(2) as ViewResult;

            NUnit.Framework.Assert.That(result.ViewName, Is.EqualTo(expect));

        }
        [TestMethod()]
        public void correct_edit_order_status()
        {
            Order_statusController obj = new Order_statusController();

            var expect = "Edit";
            ViewResult result = obj.Edit(3) as ViewResult;

            NUnit.Framework.Assert.That(result.ViewName, Is.EqualTo(expect));

        }

        public class CheckPropertyValidation
        {
            public IList<ValidationResult> myValidation(object model)
            {
                var result = new List<ValidationResult>();
                var validationContext = new ValidationContext(model);
                Validator.TryValidateObject(model, validationContext, result);
                if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);

                return result;



            }
        }

        [TestMethod()]
        public void verifyclassattributes_ship()
        {
            CheckPropertyValidation cpv = new CheckPropertyValidation();
            var ship = new shipping
            {

                shipping_name = "Krishna",
                shipping_email = "krishna@gmail.com",
                shipping_phone = "0123456789"

            };
            var errorcount = cpv.myValidation(ship).Count();
            NUnit.Framework.Assert.AreEqual(0, errorcount);


        }
        [TestMethod()]
        public void verify_wrong_classattributes_ship()
        {
            CheckPropertyValidation cpv = new CheckPropertyValidation();
            var ship = new shipping
            {

                shipping_name = "",
                shipping_email = "",
                shipping_phone = "0123456789"

            };
            var errorcount = cpv.myValidation(ship).Count();
            NUnit.Framework.Assert.AreNotEqual(0, errorcount);


        }
        [TestMethod()]
        public void verifyclassattributes_order_status()
        {
            CheckPropertyValidation cpv = new CheckPropertyValidation();
            var ship = new Order_status
            {

                Order_status_status = "Krishna",

            };
            var errorcount = cpv.myValidation(ship).Count();
            NUnit.Framework.Assert.AreEqual(0, errorcount);


        }
        [TestMethod()]
        public void verify_wrong_classattributes_order_status()
        {
            CheckPropertyValidation cpv = new CheckPropertyValidation();
            var ship = new Order_status
            {

                Order_status_status = ""


            };
            var errorcount = cpv.myValidation(ship).Count();
            NUnit.Framework.Assert.AreNotEqual(0, errorcount);


        }

        [TestMethod()]
        public void verify_wrong_classattributes_order()
        {
            CheckPropertyValidation cpv = new CheckPropertyValidation();
            var ship = new Order
            {

                Order_status_id = 1,
                Order_Date = null,
                account_id = 1,
                Order_note = "",
                Order_total_money = 15550,


            };
            var errorcount = cpv.myValidation(ship).Count();
            NUnit.Framework.Assert.AreNotEqual(0, errorcount);


        }

    }
}
