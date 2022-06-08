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
        Project_SU22Entities db = new Project_SU22Entities();
        // GET: SlideAdmin
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            
            var slAc = db.Slides.OrderByDescending(x => x.createdate).Where(x => x.status_id == true).ToPagedList(page, pageSize);
            var slide = db.Slides.OrderByDescending(x => x.createdate).ToPagedList(page, pageSize);
            SlideModel sl = new SlideModel();
            sl.slide = slide;
            sl.slActive = slAc;
            return View(sl);
        }

        public ActionResult InsertActive(int Id)
        {
            Slide slide = db.Slides.Where(x => x.id == Id).FirstOrDefault();
            slide.status_id = true;
            db.Entry(slide).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "SlideAdmin");
        }

        public ActionResult DeleteSlideActive(int Id)
        {
            Slide slide = db.Slides.Where(x => x.id == Id).FirstOrDefault();
            slide.status_id = false;
            db.Entry(slide).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "SlideAdmin");
        }
    }
}