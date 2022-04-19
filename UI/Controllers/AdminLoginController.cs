using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_KAMP.Controllers
{
    public class AdminLoginController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        [HttpGet]
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPage(Admin adminData)
        {
            var adminInfo=adminManager.GetByFilter(adminData);
            if(adminInfo !=null)
            {
                FormsAuthentication.SetAuthCookie(adminInfo.UserName, false);
                Session["UserName"] = adminInfo.UserName;
                Session["AdminId"] = adminInfo.AdminId;
                return RedirectToAction("GetAll", "AdminCategory");
            }
            else
            {
                return RedirectToAction("LoginPage");
            }
           
        }
        
    }
}