using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Testing.Tests.Models
{
    class ProductValidation : IProductValidate
    {
        public string CheckInputImage(product product)
        {
            if (product.product_image == "")
            {
                return "ImageProduct is not empty";
            }
            else
            {
                return "True";
            }
        }

        public string CheckInputProductName(product product)
        {
            if (product.product_name == "")
            {
                return "Product Name is not empty";
            } else if (product.product_name.Length < 10 || product.product_name.Length > 100)
            {
                return "Use 10-50 characters";
            } else
            {
                return "True";
            }
        }
    }
}
