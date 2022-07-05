using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Tests.Models
{
    interface IBlogValidate
    {
        string CheckInputTitleBlog(Blog blog);
        string CheckInputAuthorBlog(Blog blog);
        string CheckInputDescriptionBlog(Blog blog);
        string CheckInputCreateByBlog(Blog blog);
        string CheckInputModifyByBlog(Blog blog);

    }
}
