using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_KAMP.Controllers
{
    public class AdminAboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal()); 

       
       public ActionResult GetAll()
        {
            var aboutData = aboutManager.GetAll();
            return View(aboutData);  
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(About about)
        {
            aboutManager.Create(about);
            return RedirectToAction("GetAll");
        }
        public PartialViewResult PartialCreate()
        {
            return PartialView();
        }
    }
}