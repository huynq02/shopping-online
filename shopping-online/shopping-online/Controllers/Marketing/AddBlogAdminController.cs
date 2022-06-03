using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers.Marketing
{
    public class AddBlogAdminController : Controller
    {
        Project_SU22Entities db = new Project_SU22Entities();
        // GET: AddBlogAdmin
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Create(Blog entity, string des)
        {
            entity.descriptions = "Tất cả các thương hiệu xa xỉ đều rao giảng về sự quý hiếm và độc quyền của họ, nhưng rất ít trong số họ có đủ can đảm để trở nên khó nắm bắt và kín đáo theo bất kỳ cách nào tron...";
            db.Blogs.Add(entity);
            db.SaveChanges();
            return RedirectToAction("Index", "BlogAdmin");

        }
    }
}