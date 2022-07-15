using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using shopping_online.Context;
using shopping_online.Controllers;
using shopping_online.Controllers.HomePage;
using shopping_online.Controllers.Sale;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace shopping_onlineTests1
{
    [TestClass]
    public class UnitTest1
    {
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
        public void verify_wrong_classattributes_order_create()
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
        public void correct_Index_Order_status()
        {
            Order_statusController obj = new Order_statusController();

            var expect = "Index";


            var actResult = obj.Index() as ViewResult;
            var a = actResult.ViewName;

            NUnit.Framework.Assert.That(a, Is.EqualTo(expect));

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
        public void correct_delete_order()
        {
            OrderController obj = new OrderController();

            var expect = "Delete";
            ViewResult result = obj.Delete(2) as ViewResult;

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
        [TestMethod()]
        public void verifyclassattributes_ship_create()
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
        public void verify_wrong_classattributes_ship_create()
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
        public void verifyclassattributes_order_status_create()
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
        public void verify_wrong_classattributes_order_status_create()
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
        public void correct_delete_ship()
        {
            shippingsController obj = new shippingsController();

            var expect = "Delete";
            ViewResult result = obj.Delete(3) as ViewResult;

            NUnit.Framework.Assert.That(result.ViewName, Is.EqualTo(expect));

        }

        [TestMethod()]
        public void deleteship()
        {
            shippingsController obj = new shippingsController();

            var actResult = obj.Delete(3) as ViewResult;

            NUnit.Framework.Assert.IsNotNull(actResult);

        }
        [TestMethod()]
        public void deleteshipfail()
        {
            shippingsController obj = new shippingsController();

            var actResult = obj.Delete(100) as ViewResult;

            NUnit.Framework.Assert.IsNull(actResult);

        }

        [TestMethod()]
        public void fail_delete_ship()
        {
            shippingsController obj = new shippingsController();

            //var expect = "Delete";
            ViewResult result = obj.Delete(10000) as ViewResult;

            NUnit.Framework.Assert.IsNull(result);

        }


        [TestMethod()]
        public void fail_delete_orderStatus()
        {
            Order_statusController obj = new Order_statusController();

            //var expect = "Delete";
            ViewResult result = obj.Delete(10000) as ViewResult;

            NUnit.Framework.Assert.IsNull(result);

        }


        [TestMethod()]
        public void correct_delete_order_status()
        {
            Order_statusController obj = new Order_statusController();

            var expect = "Delete";
            ViewResult result = obj.Delete(2) as ViewResult;

            NUnit.Framework.Assert.That(result.ViewName, Is.EqualTo(expect));

        }
        [TestMethod()]
        public void deleteorder_status()
        {
            Order_statusController obj = new Order_statusController();
            var actResult = obj.Delete(2) as ViewResult;

            NUnit.Framework.Assert.IsNotNull(actResult);

        }




        [TestMethod()]
        public void CheckOrder_statusExist()
        {
            var obj = new OrderStatusAccess();

            var Res = obj.checkOrder_exist_status(1);

            NUnit.Framework.Assert.That(Res, Is.True);
        }


        [TestMethod()]
        public void ChecOrder_satusExistWithMoq()
        {
            //Create Fake Object
            var fakeObject = new Mock<IOrderStatusAccess>();
            //Set the Mock Configuration
            //The CheckDeptExist() method is call is set with the Integer parameter type
            //The Configuration also defines the Return type from the method  
            fakeObject.Setup(x => x.checkOrder_exist_status(It.IsAny<int>())).Returns(true);
            //Call the methid
            var Res = fakeObject.Object.checkOrder_exist_status(1);

            NUnit.Framework.Assert.That(Res, Is.True);
        }

        [TestMethod()]
        public void ChecshipsExistWithMoq()
        {
            var fakeObject = new Mock<IShipAccess>();
            fakeObject.Setup(x => x.check_ship_exist_status(It.IsAny<int>())).Returns(true);
            var Res = fakeObject.Object.check_ship_exist_status(1);
            NUnit.Framework.Assert.That(Res, Is.True);
        }
        [TestMethod()]
        public void Indexlisthome()
        {
            ListHomeController obj = new ListHomeController();

            var actResult = obj.Index("a", 1, 9) as ViewResult;

            NUnit.Framework.Assert.IsNotNull(actResult);

        }
        [TestMethod()]
        public void IndexlisthomebySearchNumber()
        {
            ListHomeController obj = new ListHomeController();

            var actResult1 = obj.Index("9", 1, 9) as ViewResult;

            NUnit.Framework.Assert.IsNotNull(actResult1);

        }

        [TestMethod()]
        public void IndexlistPage()
        {
            PageProductController obj = new PageProductController();

            var actResult = obj.Index(1, 9) as ViewResult;

            NUnit.Framework.Assert.IsNotNull(actResult);

        }
        [TestMethod()]
        public void IndexlistProductByCategory()
        {
            ProductByCategoryController obj = new ProductByCategoryController();

            var actResult = obj.Index(1) as ViewResult;

            NUnit.Framework.Assert.IsNotNull(actResult);

        }


        [TestMethod()]
        public void IndexlistProductByColor()
        {
            ProductByColorController obj = new ProductByColorController();

            var actResult = obj.Index(1) as ViewResult;

            NUnit.Framework.Assert.IsNotNull(actResult);

        }


        [TestMethod()]
        public void IndexlistProduct()
        {
            ProductController obj = new ProductController();

            var actResult = obj.Index(1) as ViewResult;

            NUnit.Framework.Assert.IsNotNull(actResult);

        }


        [TestMethod()]
        public void Chec_ships_delete_WithMoq()
        {
            var fakeObject = new Mock<IShipAccess>();
            fakeObject.Setup(x => x.delete_ship(2));
            var Res = fakeObject.Object.check_ship_exist_status(2);
            NUnit.Framework.Assert.That(Res, Is.False);
        }
        [TestMethod()]
        public void Check_orderstatus_delete_WithMoq()
        {
            var fakeObject = new Mock<IOrderStatusAccess>();
            fakeObject.Setup(x => x.delete_Oder_status(1));
            var Res = fakeObject.Object.checkOrder_exist_status(1);
            NUnit.Framework.Assert.That(Res, Is.False);
        }

       

    }
}
