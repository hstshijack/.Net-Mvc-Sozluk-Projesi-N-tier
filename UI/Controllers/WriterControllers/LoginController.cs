using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_KAMP.Controllers.WriterControllers
{
    public class LoginController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        
        [HttpGet]
       
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPage(Writer writerData)
        {
            var writerInfo = writerManager.GetByFilter(writerData);
            if (writerInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerInfo.Mail, false);
                Session["Mail"] = writerInfo.Mail;
                Session["WriterId"] = writerInfo.WriterId;
                return RedirectToAction("HomePage", "Default");
            }
            else
            {
                return RedirectToAction("LoginPage");
            }

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Default", "Default");
        }
    }
}