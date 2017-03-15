using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            int id = int.Parse(Request["id"]);
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public ActionResult Add(string id)
        {
            ViewBag.Id2 = id;
            return View();
        }

        public ActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPerson(Person person)
        {
            ViewData.Model = person;
            return View("AddPerson1");
        }

        public ActionResult Say()
        {
            return Content("say");
        }

        public ActionResult RedirectTest()
        {
            return Redirect(Url.Action("Index", "Hello"));
        }

        public ActionResult JsonTest()
        {
            Person p = new Person()
            {
                Age = 10,
                Qq = "3942241"
            };
            return Json(p,JsonRequestBehavior.AllowGet);
        }
    }
}