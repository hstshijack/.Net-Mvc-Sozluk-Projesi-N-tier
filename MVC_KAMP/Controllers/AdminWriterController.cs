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
    public class AdminWriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriteValidator writerValidator = new WriteValidator();
        public ActionResult GetAll()
        {
            var writerData = writerManager.GetAll();
            return View(writerData);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Writer writer)
        {
       
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writerManager.Create(writer);
                return RedirectToAction("GetAll");
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
        [HttpGet]
        public ActionResult Update(int id)
        {
            var writer = writerManager.GetById(id);
            return View(writer);
        }

        [HttpPost]
        public ActionResult Update(Writer writer)
        {
            ValidationResult results = writerValidator.Validate(writer);
            if(results.IsValid)
            {
                writerManager.Update(writer);
                return RedirectToAction("GetAll");
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

        public ActionResult Delete(int id)
        {
            var writer = writerManager.GetById(id);
            writerManager.Delete(writer);
            return RedirectToAction("GetAll");
        }
    }
}