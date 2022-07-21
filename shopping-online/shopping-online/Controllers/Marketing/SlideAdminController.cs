using PagedList;
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
    public class SlideAdminController : Controller
    {
        DBContext db = new DBContext();
        // GET: SlideAdmin
        [Authorize(Roles = "Admin, Marketing")]

        public ActionResult Index(string search, int page = 1, int pageSize = 5)
        {
            if (Session["account_id"] != null)
            {
                ViewBag.id = Session["account_id"];
                ViewBag.image = Session["account_image"];
                var slAc = db.Slides.OrderByDescending(x => x.slide_createdate).Where(x => x.slide_status_id == true).ToPagedList(page, pageSize);
                var slide = db.Slides.OrderByDescending(x => x.slide_createdate).ToPagedList(page, pageSize);
                if (search != null)
                {
                    slide = db.Slides.Where(x => x.slide_title.Contains(search)).OrderByDescending(x => x.slide_createdate).ToPagedList(page, pageSize);
                }
                SlideModel sl = new SlideModel();
                sl.slide = slide;
                sl.slActive = slAc;
                sl.search = search;
                return View(sl);

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

            //
            
        }
        [Authorize(Roles = " Marketing")]

        public ActionResult InsertActive(int Id)
        {
            if (Session["account_id"] != null)
            {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];

                Slide slide = db.Slides.Where(x => x.slide_id == Id).FirstOrDefault();
                slide.slide_status_id = true;
                db.Entry(slide).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "SlideAdmin");

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
           
        }
        [Authorize(Roles = " Marketing")]

        public ActionResult DeleteSlideActive(int Id)
        {

            if (Session["account_id"] != null)
            {
                ViewBag.image = Session["account_image"];
                ViewBag.id = Session["account_id"];

                Slide slide = db.Slides.Where(x => x.slide_id == Id).FirstOrDefault();
                slide.slide_status_id = false;
                db.Entry(slide).State = EntityState.Modified;
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