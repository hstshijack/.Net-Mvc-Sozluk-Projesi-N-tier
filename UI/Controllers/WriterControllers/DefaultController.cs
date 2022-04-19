using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_KAMP.Controllers.WriterControllers
{
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult HomePage()
        {

            var headings = headingManager.GetAll();
            return View(headings);
        }
      
        public PartialViewResult ContentPartial(int p=1)
        {
            var contents = contentManager.GetAll().ToPagedList(p, 5);  
            return PartialView(contents);
        }
    }
}