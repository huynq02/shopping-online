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
    class SlideTest
    {
        SlideValidate slValidate = new SlideValidate();
        [TestCase]
        public void CheckInputTitleEmpty()
        {
            Slide slide = new Slide();
            slide.slide_title = "";
            string result = slValidate.CheckInputTitle(slide);
            Assert.AreEqual("Title is not empty", result);
        }
        [TestCase]
        public void CheckInputTitleLength()
        {
            Slide slide = new Slide();
            slide.slide_title = "A";
            string result = slValidate.CheckInputTitle(slide);
            Assert.AreEqual("Use 10-150 characters", result);
        }
        [TestCase]
        public void CheckInputTitleTrue()
        {
            Slide slide = new Slide();
            slide.slide_title = "Siêu Sale Trong Năm Triêu Ưu Đãi";
            string result = slValidate.CheckInputTitle(slide);
            Assert.AreEqual("True", result);
        }
        [TestCase]
        public void CheckInputCreateEmpty()
        {
            Slide slide = new Slide();
            slide.slide_createby = "";
            string result = slValidate.CheckUInputCreateBy(slide);
            Assert.AreEqual("CreateBy is not empty", result);
        }
        [TestCase]
        public void CheckInputCreateLength()
        {
            Slide slide = new Slide();
            slide.slide_createby = "A";
            string result = slValidate.CheckUInputCreateBy(slide);
            Assert.AreEqual("Use 5-70 characters", result);
        }
        [TestCase]
        public void CheckInputCreateTrue()
        {
            Slide slide = new Slide();
            slide.slide_createby = "Nguyễn Kiều Tuấn Anh";
            string result = slValidate.CheckUInputCreateBy(slide);
            Assert.AreEqual("True", result);
        }

        [TestCase]
        public void CheckInputDescriptionEmpty()
        {
            Slide slide = new Slide();
            slide.slide_descriptions = "";
            string result = slValidate.CheckInputDescription(slide);
            Assert.AreEqual("Descriptions is not empty", result);
        }
        [TestCase]
        public void CheckInputDescriptionLength()
        {
            Slide slide = new Slide();
            slide.slide_descriptions = "A";
            string result = slValidate.CheckInputDescription(slide);
            Assert.AreEqual("Use 5-15000 characters", result);
        }
        [TestCase]
        public void CheckInputDescriptionTrue()
        {
            Slide slide = new Slide();
            slide.slide_descriptions = "aaaaaaaaaaaaaaaaaaaaaaaaaa";
            string result = slValidate.CheckInputDescription(slide);
            Assert.AreEqual("True", result);
        }
        [TestCase]
        public void CheckInputImageEmpty()
        {
            Slide slide = new Slide();
            slide.slide_imageslide = "";
            string result = slValidate.CheckInputImage(slide);
            Assert.AreEqual("Imageslide is not empty", result);
        }
        [TestCase]
        public void CheckInputImageTrue()
        {
            Slide slide = new Slide();
            slide.slide_imageslide = "A.png";
            string result = slValidate.CheckInputImage(slide);
            Assert.AreEqual("True", result);
        }
    }
}
