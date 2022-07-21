using shopping_online.Context;
using shopping_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers
{
    public class SlideController : Controller
    {
        // GET: Slide
        DBContext db = new DBContext();
        public ActionResult Index()
        {
            ViewBag.image = Session["account_image"];
            ViewBag.id = Session["account_id"];
            var slide = db.Slides.Where(x => x.slide_status_id == true).ToList();
            SlideModel sl = new SlideModel();
            sl.slDis = slide;
            return View(sl);
        }
    }
}