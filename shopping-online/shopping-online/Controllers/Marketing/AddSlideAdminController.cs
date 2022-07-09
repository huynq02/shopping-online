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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Slide slide)
        {
            // 
            db.Slides.Add(slide);
            db.SaveChanges();
            return RedirectToAction("Index", "SlideAdmin");
        }
        public ActionResult SlideNeedEdit(int Id)
        {
            var slide = db.Slides.Where(x => x.slide_id == Id).FirstOrDefault();
            SlideModel sl = new SlideModel();
            sl.sl = slide;
            return View(sl);
        }

        [HttpPost]
        public ActionResult Edit(Slide sl, int Id, string img, string Status_id)
        {
            if (sl.slide_imageslide == null)
            {
                sl.slide_imageslide = img;
            }
            sl.slide_id = Id;
            if (Status_id.ToLower() == "value")
            {
                sl.slide_status_id = true;
            } else
            {
                sl.slide_status_id = false;
            }
            db.Entry(sl).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "SlideAdmin");
        }

        public ActionResult Delete(int Id)
        {
            Slide slide = db.Slides.Where(x => x.slide_id == Id).FirstOrDefault();
            db.Slides.Remove(slide);
            db.SaveChanges();
            return RedirectToAction("Index", "SlideAdmin");
        }
    }
}