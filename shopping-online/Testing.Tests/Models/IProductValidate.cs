using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Tests.Models
{
    interface IProductValidate
    {
        string CheckInputProductName(product product);
        string CheckInputImage(product product);
    }
}
