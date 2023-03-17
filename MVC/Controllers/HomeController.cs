using Project.BLL.DesignPatterns.SingletonPattern;
using Project.BLL.Generic_Repository.ConcRep;
using Project.DAL.ContextClasses;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        MyContext db;
        BookRepository rep;
        public HomeController()
        {
            db = DBTool.DB;
            rep = new BookRepository();
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
    }
}