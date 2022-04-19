using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_KAMP.Controllers
{
    public class AdminMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            string mail = (string)Session["UserName"];
            var messageList = messageManager.GetAllInbox(mail);
            return View(messageList);
        }
        public ActionResult SendBox()
        {
            string mail = (string)Session["UserName"];
            var messageList = messageManager.GetAllSendBox(mail);
            return View(messageList);   
        }
        public ActionResult InboxDetails(int id)
        {
            var message = messageManager.GetById(id);
            return View(message);
        }
        public ActionResult SendBoxDetails(int id)
        {
            var message = messageManager.GetById(id);
            return View(message);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult Create(Message message)
        {
            ValidationResult results = messageValidator.Validate(message);
            if (results.IsValid)
            {
                message.Date = DateTime.Parse(DateTime.Now.ToString());    
                messageManager.Create(message);
                return RedirectToAction("Inbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
           
        }
    }
}