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
    public class AddSlideAdminController : Controller
    {
        DBContext db = new DBContext();
        // GET: AddSlideAdmin
        [Authorize(Roles = "Admin,  Marketing")]
        public ActionResult Index()
        {
            ViewBag.image = Session["account_image"];
            ViewBag.id = Session["account_id"];

            return View();
        }
        [Authorize(Roles = " Marketing")]

        public ActionResult Create(Slide slide,string Title, string Descriptions, string CreateBy, string ModifyBy,
            string CreateDate, string ModifyDate, string Imageslide)
        {
            if (Session["account_id"] != null)
            {

                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                slide.slide_title = Title;
                slide.slide_descriptions = Descriptions;
                slide.slide_createby = CreateBy;
                slide.slide_modifyby = ModifyBy;
                slide.slide_status_id = false;
                slide.slide_imageslide = Imageslide;
                slide.slide_createdate = DateTime.ParseExact(CreateDate, "yyyy-MM-dd", null);
                slide.slide_modifydate = DateTime.ParseExact(ModifyDate, "yyyy-MM-dd", null);
                db.Slides.Add(slide);
                db.SaveChanges();
                return RedirectToAction("Index", "SlideAdmin");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }
        [Authorize(Roles = " Marketing")]

        public ActionResult SlideNeedEdit(int Id)
        {
            if (Session["account_id"] != null)
            {

                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                var slide = db.Slides.Where(x => x.slide_id == Id).FirstOrDefault();
                SlideModel sl = new SlideModel();
                sl.sl = slide;
                return View(sl);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }
        [Authorize(Roles = " Marketing")]


        [HttpPost]
        public ActionResult Edit(Slide sl, int Id, string img, string Status_id)
        {
            if (Session["account_id"] != null)
            {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];
                if (sl.slide_imageslide == null)
                {
                    sl.slide_imageslide = img;
                }
                sl.slide_id = Id;
                if (Status_id.ToLower() == "value")
                {
                    sl.slide_status_id = true;
                }
                else
                {
                    sl.slide_status_id = false;
                }
                db.Entry(sl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "SlideAdmin");
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
                Slide slide = db.Slides.Where(x => x.slide_id == Id).FirstOrDefault();
                db.Slides.Remove(slide);
                db.SaveChanges();
                return RedirectToAction("Index", "SlideAdmin");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
           
        }
    }
}