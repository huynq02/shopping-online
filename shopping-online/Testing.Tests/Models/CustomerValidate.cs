using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Testing.Tests.Models
{
    class CustomerValidate : ICustomerValidate
    {
        public string CheckInputEmail(Account customer)
        {
            string a = "^[a-z][a-z0-9_.]{5,32}@[a-z0-9]{2,}(.[a-z0-9]{2,4}){1,2}$";
            Regex regex = new Regex(a);
            if (customer.account_email == "")
            {
                return "Email is not empty";
            } else if (!regex.IsMatch(customer.account_email))
            {
                return "E-mail is not valid or Use letters, numbers & preriods or Must be between 5-32 character or Not special character ";
            } else
            {
                return "True";
            }
        }

        public string CheckInputFullName(Account customer)
        {
            if (customer.account_name == "")
            {
                return "FullName is not empty";
            } else if (customer.account_name.Length < 5 || customer.account_name.Length > 50)
            {
                return "Use 5-50 characters";
            } else
            {
                return "True";
            }
        }

        public string CheckInputPhone(Account customer)
        {
            string a = "^(?:[+0]9)?[0-9]{10}$";
            Regex regex = new Regex(a);
            if (customer.account_phone == "")
            {
                return "Phone is not empty";
            } else if (customer.account_phone.Length < 9 || customer.account_phone.Length > 12)
            {
                return "Use 9-12 characters";
            } else if (regex.IsMatch(customer.account_phone))
            {
                return "Phone is not valid and Use numbers and 0 is first character";
            } else
            {
                return "True";
            }
        }

        public string CheckInputUserName(Account customer)
        {
            if (customer.account_username == "")
            {
                return "Username is not empty";
            }
            else if (customer.account_username.Length < 5 || customer.account_username.Length > 50)
            {
                return "Use 5-50 characters";
            }
            else
            {
                return "True";
            }
        }
    }
}
