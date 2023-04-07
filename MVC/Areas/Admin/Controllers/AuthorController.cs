using Project.BLL.Generic_Repository.ConcRep;
using Project.ViewModels.VMClasses;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    public class AuthorController : Controller
    {
        AuthorRepository _repAuthor;
        public AuthorController()
        {
            _repAuthor = new AuthorRepository();
        }
        // GET: Admin/Author
        public ActionResult ListAuthor()
        {
            List<AdminAuthorVM> authorVM = _repAuthor.Select(x => new AdminAuthorVM
            {
                FirstName = x.FirstName,
                ID = x.ID,
                LastName = x.LastName

            }).ToList();
            return View(authorVM);
        }
        public ActionResult AddAuthor()
        {
            return View();
        }

      
    }
}