using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping_online.Controllers.Marketing
{
    public class UpdateProfileController : Controller
    {
        // GET: UpdateProfile
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConfirmPass()
        {
            return RedirectToAction("Index");
        }

        public ActionResult SaveChangePro()
        {
            return RedirectToAction("Index");
        }

        public ActionResult CapCha()
        {
            return View();
        }
    }
}