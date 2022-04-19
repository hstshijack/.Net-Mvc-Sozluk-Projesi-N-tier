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
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult GetAll(int p=1)
        {
            string mail = (string)Session["Mail"];
            int writerId = writerManager.GetByMail(mail).WriterId;
            var contents=contentManager.GetListByWriter(writerId).ToPagedList(p,4);
            return View(contents);
        }
        public ActionResult GetByHeading(int id)
        {
            var contents=contentManager.GetListByHeadingId(id);
            if(contents.Count != 0)
            {
                ViewBag.headingName = contents[0].Heading.Name;
            }
         
            return View(contents);   
        }
        
    }
}