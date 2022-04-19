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
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        CategoryValidator categoryValidator = new CategoryValidator();
        [Authorize(Roles="C")]
        public ActionResult GetAll()
        {
            var categoryData = categoryManager.GetAll();
            return View(categoryData);
        }
        [HttpGet]
        public ActionResult Create()
        {
     
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
        
            ValidationResult results=categoryValidator.Validate(category);
            if(results.IsValid)
            {
                categoryManager.Create(category);
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
            var Category = categoryManager.GetById(id);
            return View(Category);
        }

        [HttpPost]
        public ActionResult Update(Category category)
        {
            categoryManager.Update(category);
            return RedirectToAction("GetAll");
        }

        public ActionResult Delete(int id )
        {
            var Category=categoryManager.GetById(id);
            categoryManager.Delete(Category);
            return RedirectToAction("GetAll");
        }

    }
}