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
    class BlogTesst
    {
        BlogValidate blogValidate = new BlogValidate();
        [TestCase]
        public void ShowResultTestBlogTitleEmpty()
        {
            Blog blog = new Blog();
            blog.blog_title = "";
            string result = blogValidate.CheckInputTitleBlog(blog);
            Assert.AreEqual("Mời nhập Title", result);
        }

        [TestCase]
        public void ShowResultTestBlogTitleLength()
        {
            Blog blog = new Blog();
            blog.blog_title = "A";
            string result = blogValidate.CheckInputTitleBlog(blog);
            Assert.AreEqual("Use 10-150 characters", result);
        }

        [TestCase]
        public void ShowResultTestBlogTitleTrue()
        {
            Blog blog = new Blog();
            blog.blog_title = "Nguyễn Kiều Tuấn Anh";
            string result = blogValidate.CheckInputTitleBlog(blog);
            Assert.AreEqual("True", result);
        }
        [TestCase]
        public void ShowResultTestBlogAuthorEmpty()
        {
            Blog blog = new Blog();
            blog.blog_author = "";
            string result = blogValidate.CheckInputAuthorBlog(blog);
            Assert.AreEqual("Mời nhập Author", result);
        }

        [TestCase]
        public void ShowResultTestBlogAuthorLength()
        {
            Blog blog = new Blog();
            blog.blog_author = "A";
            string result = blogValidate.CheckInputAuthorBlog(blog);
            Assert.AreEqual("Use 5-100 characters", result);
        }

        [TestCase]
        public void ShowResultTestBlogAuthorTrue()
        {
            Blog blog = new Blog();
            blog.blog_author = "Nguyễn Kiều Tuấn Anh";
            string result = blogValidate.CheckInputAuthorBlog(blog);
            Assert.AreEqual("True", result);
        }
        [TestCase]
        public void ShowResultTestBlogCreateByEmpty()
        {
            Blog blog = new Blog();
            blog.blog_createby = "";
            string result = blogValidate.CheckInputCreateByBlog(blog);
            Assert.AreEqual("Mời nhập Create By", result);
        }

        [TestCase]
        public void ShowResultTestBlogCreateByLength()
        {
            Blog blog = new Blog();
            blog.blog_createby = "A";
            string result = blogValidate.CheckInputCreateByBlog(blog);
            Assert.AreEqual("Use 5-100 characters", result);
        }

        [TestCase]
        public void ShowResultTestBlogCreateByTrue()
        {
            Blog blog = new Blog();
            blog.blog_createby = "Nguyễn Kiều Tuấn Anh";
            string result = blogValidate.CheckInputCreateByBlog(blog);
            Assert.AreEqual("True", result);
        }
        [TestCase]
        public void ShowResultTestBlogDescriptionEmpty()
        {
            Blog blog = new Blog();
            blog.blog_descriptions = "";
            string result = blogValidate.CheckInputDescriptionBlog(blog);
            Assert.AreEqual("Mời nhập Description", result);
        }

        [TestCase]
        public void ShowResultTestBlogDescriptionLength()
        {
            Blog blog = new Blog();
            blog.blog_descriptions = "A";
            string result = blogValidate.CheckInputDescriptionBlog(blog);
            Assert.AreEqual("Use 10-300 characters", result);
        }

        [TestCase]
        public void ShowResultTestBlogDescriptionTrue()
        {
            Blog blog = new Blog();
            blog.blog_descriptions = "Nguyễn Kiều Tuấn Anh";
            string result = blogValidate.CheckInputDescriptionBlog(blog);
            Assert.AreEqual("True", result);
        }

        
    }
}
