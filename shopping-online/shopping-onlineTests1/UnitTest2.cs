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
using System.Web.Mvc;

namespace shopping_onlineTests1
{
    [TestClass]
    public class UnitTest2
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
        public void IndexOrder()
        {
            OrderController obj = new OrderController();

            var actResult = obj.Index("a", 1) as ViewResult;

            NUnit.Framework.Assert.IsNotNull(actResult);
        }


        //[TestMethod()]
        //public void Indexlisthome()
        //{
        //    ListHomeController obj = new ListHomeController();

        //    var actResult = obj.Index() as ViewResult;

        //    NUnit.Framework.Assert.IsNotNull(actResult);

        //}


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
        public void correct_create_Order()
        {
            OrderController obj = new OrderController();

            var expect = "Create";
            ViewResult result = obj.Create() as ViewResult;

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
        public void deleteorder()
        {
            OrderController obj = new OrderController();
            var actResult = obj.Delete(2) as ViewResult;

            NUnit.Framework.Assert.IsNotNull(actResult);

        }

        [TestMethod()]
        public void CheckOrderExist()
        {
            var obj = new OrderAccess();

            var Res = obj.checkOrder_exist(1);

            NUnit.Framework.Assert.That(Res, Is.True);
        }

        [TestMethod()]
        public void ChecOrderExistWithMoq()
        {
            //Create Fake Object
            var fakeObject = new Mock<IOrderAccess>();
            //Set the Mock Configuration
            //The CheckDeptExist() method is call is set with the Integer parameter type
            //The Configuration also defines the Return type from the method  
            fakeObject.Setup(x => x.checkOrder_exist(It.IsAny<int>())).Returns(true);
            //Call the methid
            var Res = fakeObject.Object.checkOrder_exist(1);

            NUnit.Framework.Assert.That(Res, Is.True);
        }

        [TestMethod()]
        public void ChecsOrdercreateWithMoq()
        {
            var fakeObject = new Mock<IOrderAccess>();
            fakeObject.Setup(x => x.delete_Oder(1));
            var Res = fakeObject.Object.checkOrder_exist(1);
            NUnit.Framework.Assert.That(Res, Is.False);
        }



    }
}
