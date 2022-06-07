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
        public ActionResult Index(int page = 1, int pageSize = 1)
        {
            //var slAc = db.Slides.Where(x => x.status_id == 1).ToList();
            var slide = db.Slides.OrderByDescending(x => x.createdate).ToPagedList(page, pageSize);
            SlideModel sl = new SlideModel();
            sl.slide = slide;
            //sl.slActive = slAc;
            return View(sl);
        }

        //Insert Slide

        public ActionResult Create(Slide slide)
        {
            db.Slides.Add(slide);
            db.SaveChanges();
            return RedirectToAction("Index", "SlideAdmin");
        }

        public ActionResult InsertActive(int Id)
        {

            return RedirectToAction("Index", "SlideAdmin");
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Slide slide = db.Slides.Where(x => x.id == Id).FirstOrDefault();
            //slide.status_id = 2;
            db.Entry(slide).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "SlideAdmin");
        }
    }
}