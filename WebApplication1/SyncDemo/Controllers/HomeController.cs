using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SyncDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CalsAdd(int calc1, int calc2)
        {
            return Content((calc1 + calc2).ToString());
        }

        public ActionResult CalsAdd1(int calc1, int calc2)
        {
            int sum = calc1 + calc2;
            var temp = new
            {
                Sum = sum
            };
            return Json(temp,JsonRequestBehavior.AllowGet);
        }
    }
}