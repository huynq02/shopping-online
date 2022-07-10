using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Tests.Models
{
    class BlogValidate : IBlogValidate
    {
        //DBContext db = new DBContext();
        public string CheckInputAuthorBlog(Blog blog)
        {
            if (blog.blog_author=="")
            {
                return "Mời nhập Author";
            } else if (blog.blog_author.Length < 5 || blog.blog_author.Length > 100)
            {
                return "Use 5-100 characters";
            }
            return "True";
        }

        public string CheckInputCreateByBlog(Blog blog)
        {
            if (blog.blog_createby == "")
            {
                return "Mời nhập Create By";
            }
            else if (blog.blog_createby.Length < 5 || blog.blog_createby.Length > 100)
            {
                return "Use 5-100 characters";
            }
            return "True";
        }

        public string CheckInputDescriptionBlog(Blog blog)
        {
            if (blog.blog_descriptions == "")
            {
                return "Mời nhập Description";
            }
            else if (blog.blog_descriptions.Length < 10 || blog.blog_descriptions.Length > 300)
            {
                return "Use 10-300 characters";
            }
            return "True";
        }

        public string CheckInputModifyByBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public string CheckInputTitleBlog(Blog blog)
        {
            if (blog.blog_title == "")
            {
                return "Mời nhập Title";
            }
            else if (blog.blog_title.Length < 10 || blog.blog_title.Length > 150)
            {
                return "Use 10-150 characters";
            }
            else
            {
                return "True";
            }
        }
    }
}
