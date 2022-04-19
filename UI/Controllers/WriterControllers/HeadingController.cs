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
using PagedList;

namespace MVC_KAMP.Controllers.WriterControllers
{
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        HeadingValidator headingValidator = new HeadingValidator();

        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult GetAll(int p=1)
        {
            string mail = (string)Session["Mail"];
            int writerId = writerManager.GetByMail(mail).WriterId;           
            var headingData = headingManager.GetAllByWriter(writerId).ToPagedList(p,6);
            return View(headingData);

        }
        [HttpGet]
        public ActionResult Create()
        {
           
            
            List<SelectListItem> categoryData = (from i in categoryManager.GetAll()

                                                 select new SelectListItem
                                                 {
                                                     Text = i.Name,
                                                     Value = i.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.categoryData = categoryData;                 
            return View();
        }
        [HttpPost]
        public ActionResult Create(Heading heading)
        {
            int wriderId = (int)Session["WriterId"];
            ValidationResult results = headingValidator.Validate(heading);
            if (results.IsValid)
            {
                heading.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                heading.Status = true;
                heading.WriterId = wriderId;
                headingManager.Create(heading);
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
            List<SelectListItem> categoryData = (from i in categoryManager.GetAll()

                                                 select new SelectListItem
                                                 {
                                                     Text = i.Name,
                                                     Value = i.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.categoryData = categoryData;

            var heading = headingManager.GetById(id);
            return View(heading);
        }

        [HttpPost]
        public ActionResult Update(Heading heading)
        {
            headingManager.Update(heading);
            return RedirectToAction("GetAll");
        }

        public ActionResult Delete(int id)
        {
            var heading = headingManager.GetById(id);
            if (heading.Status == true)
            {
                heading.Status = false;
            }
            else
            {
                heading.Status = true;
            }
            headingManager.Delete(heading);
            return RedirectToAction("GetAll");
        }
        public PartialViewResult PartialCreate()
        {
            List<SelectListItem> categoryData = (from i in categoryManager.GetAll()

                                                 select new SelectListItem
                                                 {
                                                     Text = i.Name,
                                                     Value = i.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.categoryData = categoryData;
            return PartialView();
        }
        public PartialViewResult PartialGetAll()
        {
            var heading = headingManager.GetAll();
            return PartialView(heading);
        }
    }
}