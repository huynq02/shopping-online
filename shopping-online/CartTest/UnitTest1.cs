using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using shopping_online.Context;
using shopping_online.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CartTest
{
    [TestClass]
    public class UnitTest1
    {
        DBContext db = new DBContext();

       
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
    }
}
