using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers.Marketing
{
    //Add blog
    public class AddBlogAdminController : Controller
    {
        DBContext db = new DBContext();
        // GET: AddBlogAdmin
        [Authorize(Roles = "Admin, Marketing")]
        public ActionResult Index()
        {
            if (Session["account_id"] != null)
            {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        public JsonResult uploadFile(HttpPostedFileBase uploadedFiles)
        {
            string returnImagePath = string.Empty;
            string fileName;
            string Extension;
            string imageName;
            string imageSavePath;

            if (uploadedFiles.ContentLength > 0)
            {
                fileName = System.IO.Path.GetFileNameWithoutExtension(uploadedFiles.FileName);
                Extension = System.IO.Path.GetExtension(uploadedFiles.FileName);
                imageName = fileName + DateTime.Now.ToString("yyyyMMddHHmmss");
                imageSavePath = Server.MapPath("/Content/images/") + imageName + Extension;

                uploadedFiles.SaveAs(imageSavePath);
                returnImagePath = "/Content/images/" + imageName + Extension;
            }
            return Json(Convert.ToString(returnImagePath), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = " Marketing")]
        public ActionResult Create(Blog entity, string CreateDate, string ModifyDate, string Image,
                                    string Title, string Author, string Descriptions, string CreateBy, string Detail, string ModifyBy, string Back_Link)
        {
            if (Session["account_id"] != null)
            {

                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                entity.blog_title = Title;
                entity.blog_author = Author;
                entity.blog_descriptions = Descriptions;
                entity.blog_createby = CreateBy;
                entity.blog_detail = Detail;
                entity.blog_modifyby = ModifyBy;
                entity.blog_back_link = Back_Link;
                entity.blog_createdate = DateTime.ParseExact(CreateDate, "yyyy-MM-dd", null);
                entity.blog_modifydate = DateTime.ParseExact(ModifyDate, "yyyy-MM-dd", null);
                entity.blog_images = Image;
                db.Blogs.Add(entity);
                db.SaveChanges();
                return RedirectToAction("Index", "BlogAdmin");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
    }
}