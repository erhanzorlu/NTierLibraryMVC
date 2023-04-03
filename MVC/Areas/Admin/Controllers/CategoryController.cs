using MVC.Areas.Admin.Data.AdminPageVMs;
using Project.BLL.Generic_Repository.ConcRep;
using Project.ViewModels.VMClasses;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category

        CategoryRepository _cRep;

        public CategoryController()
        {
            _cRep = new CategoryRepository();
        }
        public ActionResult ListCategories(int? id)
        {
            List<AdminCategoryVM> categories;
            if (id == null)
            {
                categories = _cRep.Select(x => new AdminCategoryVM
                {
                    ID = x.ID,
                    CategoryName = x.CategoryName,
                    Description = x.Description,
                    CreatedDate = x.CreatedTime,
                    ModifiedDate = x.UpdatedTime,
                    DeletedDate = x.DeletedTime,
                    Status = x.Status.ToString(),


                }).ToList();
            }
            else
            {
                categories = _cRep.Where(x => x.ID == id).Select(x=>new AdminCategoryVM {

                    ID = x.ID,
                    CategoryName = x.CategoryName,
                    Description = x.Description,
                    CreatedDate = x.CreatedTime,
                    ModifiedDate = x.UpdatedTime,
                    DeletedDate = x.DeletedTime,
                    Status = x.Status.ToString(),

                }).ToList();
            }
            AdminCategoryListPageVM alistVm=new AdminCategoryListPageVM()
                {

                    Categories=categories,

                };            
            return View(alistVm);
        }
    }
}