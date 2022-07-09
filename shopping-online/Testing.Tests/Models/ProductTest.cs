using NUnit.Framework;
using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Tests.Models
{
    [TestFixture]
    class ProductTest
    {
        ProductValidation proValidate = new ProductValidation();
        [TestCase] 
        public void CheckInputProductNameEmpty ()
        {
            product product = new product();
            product.product_name = "";
            string result = proValidate.CheckInputProductName(product);
            Assert.AreEqual("Product Name is not empty", result);
        }
        [TestCase]
        public void CheckInputProductNameLength()
        {
            product product = new product();
            product.product_name = "A";
            string result = proValidate.CheckInputProductName(product);
            Assert.AreEqual("Use 10-50 characters", result);
        }
        [TestCase]
        public void CheckInputProductNameTrue()
        {
            product product = new product();
            product.product_name = "aaaaaaaaaaaaaaaaaaaaaa";
            string result = proValidate.CheckInputProductName(product);
            Assert.AreEqual("True", result);
        }
        [TestCase]
        public void CheckInputImageProductEmpty()
        {
            product product = new product();
            product.product_image = "";
            string result = proValidate.CheckInputImage(product);
            Assert.AreEqual("ImageProduct is not empty", result);
        }
        [TestCase]
        public void CheckInputImageProductTrue()
        {
            product product = new product();
            product.product_name = "A.png";
            string result = proValidate.CheckInputImage(product);
            Assert.AreEqual("True", result);
        }
    }
}
