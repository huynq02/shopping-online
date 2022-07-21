using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers.Marketing
{
    public class EditBlogAdminController : Controller
    {
        DBContext db = new DBContext();
        // GET: EditBlogAdmin
        [Authorize(Roles = "Admin, Marketing")]

        public ActionResult Index(int Id)
        {
            if (Session["account_id"] != null)
            {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                var blog = db.Blogs.Where(x => x.blog_id == Id).FirstOrDefault();
                EditBlog bg = new EditBlog();
                bg.blog = blog;
                return View(bg);

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
        [Authorize(Roles = " Marketing")]

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Blog blog, int Id, string img, string Back)
        {
            if (Session["account_id"] != null)
            {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                if (blog.blog_images == null)
                {
                    blog.blog_images = img;
                }
                blog.blog_back_link = Back;
                blog.blog_id = Id;
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "BlogAdmin");

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
           
        }
        [Authorize(Roles = " Marketing")]

        public ActionResult Delete(int Id)
        {
            if (Session["account_id"] != null)
            {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                Blog blog = db.Blogs.Where(x => x.blog_id == Id).FirstOrDefault();
                db.Blogs.Remove(blog);
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