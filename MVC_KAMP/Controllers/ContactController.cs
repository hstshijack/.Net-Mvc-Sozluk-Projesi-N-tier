using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_KAMP.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();
        public ActionResult GetAll()
        {
            var contacts = contactManager.GetAll();
            return View(contacts);
        }
        public PartialViewResult PartialInboxLeftPanel()
        {
            return PartialView();
        }
        public ActionResult GetContactDetails(int id)
        {
            var contact = contactManager.GetById(id);
            return View(contact);  
        }

    }
}