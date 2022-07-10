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
    class CustomerTest
    {
        CustomerValidate cusValidate = new CustomerValidate();
        [TestCase]
        public void ShowResultTestCustomerFullNameEmpty()
        {
            Account cus = new Account();
            cus.account_name = "";
            string result = cusValidate.CheckInputFullName(cus);
            Assert.AreEqual("FullName is not empty", result);
        }
        [TestCase]
        public void ShowResultTestCustomerFullNameLength()
        {
            Account cus = new Account();
            cus.account_name = "A";
            string result = cusValidate.CheckInputFullName(cus);
            Assert.AreEqual("Use 5-50 characters", result);
        }
        [TestCase]
        public void ShowResultTestCustomerFullNameTrue()
        {
            Account cus = new Account();
            cus.account_name = "Nguyễn Kiều Tuấn Anh";
            string result = cusValidate.CheckInputFullName(cus);
            Assert.AreEqual("True", result);
        }
        [TestCase]
        public void ShowResultTestCustomerUserNameEmpty()
        {
            Account cus = new Account();
            cus.account_username = "";
            string result = cusValidate.CheckInputUserName(cus);
            Assert.AreEqual("Username is not empty", result);
        }
        [TestCase]
        public void ShowResultTestCustomerUserNameLength()
        {
            Account cus = new Account();
            cus.account_username = "A";
            string result = cusValidate.CheckInputUserName(cus);
            Assert.AreEqual("Use 5-50 characters", result);
        }
        [TestCase]
        public void ShowResultTestCustomerUserNameTrue()
        {
            Account cus = new Account();
            cus.account_username = "Nguyễn Kiều Tuấn Anh";
            string result = cusValidate.CheckInputUserName(cus);
            Assert.AreEqual("True", result);
        }
        [TestCase]
        public void ShowResultTestCustomerEmailEmpty()
        {
            Account cus = new Account();
            cus.account_email = "";
            string result = cusValidate.CheckInputEmail(cus);
            Assert.AreEqual("Email is not empty", result);
        }
        [TestCase]
        public void ShowResultTestCustomerEmailIsValid1()
        {
            Account cus = new Account();
            cus.account_email = "anhnkthe151369";
            string result = cusValidate.CheckInputEmail(cus);
            Assert.AreEqual("E-mail is not valid or Use letters, numbers & preriods or Must be between 5-32 character or Not special character ", result);
        }

        [TestCase]
        public void ShowResultTestCustomerEmailIsValid2()
        {
            Account cus = new Account();
            cus.account_email = "$@gmail.com";
            string result = cusValidate.CheckInputEmail(cus);
            Assert.AreEqual("E-mail is not valid or Use letters, numbers & preriods or Must be between 5-32 character or Not special character ", result);
        }
        [TestCase]
        public void ShowResultTestPhoneEmpty()
        {
            Account cus = new Account();
            cus.account_phone = "";
            string result = cusValidate.CheckInputPhone(cus);
            Assert.AreEqual("Phone is not empty", result);
        }
        [TestCase]
        public void ShowResultTestPhoneLength()
        {
            Account cus = new Account();
            cus.account_phone = "12345";
            string result = cusValidate.CheckInputPhone(cus);
            Assert.AreEqual("Use 9-12 characters", result);
        }
        [TestCase]
        public void ShowResultTestPhoneInvalid()
        {
            Account cus = new Account();
            cus.account_phone = "1234567899";
            string result = cusValidate.CheckInputPhone(cus);
            Assert.AreEqual("Phone is not valid and Use numbers and 0 is first character", result);
        }

    }
}
