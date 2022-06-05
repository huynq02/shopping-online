using PagedList;
using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
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
            var slide = db.Slides.OrderByDescending(x => x.createdate).ToPagedList(page, pageSize);
            SlideModel sl = new SlideModel();
            sl.slide = slide;
            return View(sl);
        }

        public ActionResult Create(int Id)
        {

            return RedirectToAction("Index", "SlideAdmin");
        }

        public ActionResult Delete(int Id)
        {

            return RedirectToAction("Index", "SlideAdmin");
        }
    }
}