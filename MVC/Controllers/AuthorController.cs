using Project.BLL.Generic_Repository.ConcRep;
using Project.ViewModels.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AuthorController : Controller
    {
        AuthorRepository authorRep;
        // GET: Author
        public AuthorController()
        {
            authorRep = new AuthorRepository();
        }
        public ActionResult ListAuthor()
        {
            List<AuthorVM> authorVM = authorRep.Select(x=> new AuthorVM
            { 
                ID=x.ID,
            FirstName=x.FirstName,
            LastName=x.LastName           
            }).ToList();

            

            return View();
        }
        public ActionResult AddAuthor()
        {
            return View();
        }
        public ActionResult UpdateAuthor()
        {
            return View();
        }
        public ActionResult DeleteAuthor()
        {
            return View();
        }
    }
}