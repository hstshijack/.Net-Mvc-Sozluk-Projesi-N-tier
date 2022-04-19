using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_KAMP.Controllers
{
    public class AdminContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult ContentByHeading(int id)
        {
            var content = contentManager.GetListByHeadingId(id);  
            return View(content);
        }
    }
}