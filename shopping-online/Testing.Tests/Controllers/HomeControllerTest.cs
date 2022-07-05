using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using shopping_online.Controllers.Marketing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Testing;
using System.ComponentModel.DataAnnotations;
namespace Testing.Tests.Controllers
{
    [TestClass]
    public class BlogAdminControllerTest
    { 
        [TestMethod]
        public void BlogAdminIndex()
        {
            BlogAdminController blogAdmin = new BlogAdminController();
            //blogAdmin.Index("A", 1, 3);
            var expect = "Index";
            var actResult = blogAdmin.Index("a", 1) as ViewResult;
            var a = actResult.ViewName;
            NUnit.Framework.Assert.That(a, Is.EqualTo(expect));
        }

        [TestMethod]
        public void Contact()
        {
           
        }
    }
}
