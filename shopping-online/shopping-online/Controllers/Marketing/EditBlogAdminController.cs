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
        Project_SU22Entities db = new Project_SU22Entities();
        // GET: EditBlogAdmin
        public ActionResult Index(int Id)
        {
            var blog = db.Blogs.Where(x => x.id == Id).FirstOrDefault();
            EditBlog bg = new EditBlog();
            bg.blog = blog;
            return View(bg);
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
        public ActionResult Edit(Blog blog, int Id, string img)
        {
            if (blog.images == null)
            {
                blog.images = img;
            }
            blog.id = Id;
            db.Entry(blog).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "BlogAdmin");
        }

        public ActionResult Delete(int Id)
        {
            Blog blog = db.Blogs.Where(x => x.id == Id).FirstOrDefault();
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index", "BlogAdmin");
        }
    }
}