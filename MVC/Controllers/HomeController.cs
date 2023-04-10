using MVC.AuthenticationClasses;
using Project.BLL.DesignPatterns.SingletonPattern;
using Project.BLL.Generic_Repository.ConcRep;
using Project.COMMON.Tools;
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
        AppUserRepository appRep;
        CategoryRepository _catRep;
        public HomeController()
        {
           
            rep = new BookRepository();
            appRep = new AppUserRepository();
            _catRep = new CategoryRepository();
         

        }
        public ActionResult Index()
        {
            Session["kategoriler"] = _catRep.GetActives();
            return View(rep.GetAll());
       
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AdminAuthentication]
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
        public ActionResult SignUp(Project.ViewModels.VMClasses.AppUserVM appUser)
        {
            if (appRep.Any(x=>x.Email==appUser.Email ))
            {
                ViewBag.Message = "Bu Eposta kayıtlı";
                return View();
            }

            appUser.Password= DantexCrypt.Crypt(appUser.Password); //Şifreyi kriptoladık.
                AppUser user = new AppUser
                {
                    Email = appUser.Email,
                    Password = appUser.Password,
                    FirstName = appUser.FirstName,
                    LastName = appUser.LastName,
                };
                appRep.Add(user);
            string gonderilecekMail = "Tebrikler hesabınız oluşturulmuştur... Hesabınızı aktive etmek için https://localhost:44314/Register/Activation/"+ user.ActivationCode+" linkine tıklayınız" ;
           // MailService.Send(appUser.Email, body: gonderilecekMail, subject: "Hesap Aktivasyonu");

                return RedirectToAction("Index");
            
          
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Project.ViewModels.VMClasses.AppUserVM appUser)
        {
            AppUser app = appRep.FirstOrdDefault(x=>x.Email==appUser.Email && x.Password==appUser.Password);
            if (app!=null)
            {
              
                Session["control"] = app;
                Session["User"] = app.FirstName+" "+app.LastName;
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Kullanıcı bulunamadı";
            return View();
        }


    }
}