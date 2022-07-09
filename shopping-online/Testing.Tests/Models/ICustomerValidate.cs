using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Tests.Models
{
    interface ICustomerValidate
    {
        string CheckInputFullName(Account customer);
        string CheckInputEmail(Account customer);
        string CheckInputUserName(Account customer);
        string CheckInputPhone(Account customer);
    }
}
