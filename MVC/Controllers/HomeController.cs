using Project.BLL.DesignPatterns.SingletonPattern;
using Project.BLL.Generic_Repository.ConcRep;
using Project.DAL.ContextClasses;
using Project.ENTITIES.Models;
using Project.ViewModels.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
      
        BookRepository rep;
        AppUserRepository AppUserRep;
        public HomeController()
        {
           
            rep = new BookRepository();
            AppUserRep = new AppUserRepository();
        }
        public ActionResult Index()
        {
           
            return View(rep.GetAll());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(AppUserVM appUser)
        {
            AppUser user = new AppUser
            {
                Email = appUser.Email,
                Password = appUser.Password,
            };
            AppUserRep.Add(user);
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AppUserVM appUser)
        {
            return View();
        }


    }
}