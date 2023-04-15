using Microsoft.Ajax.Utilities;
using MVC.Areas.Admin.Data.AdminPageVMs;
using Project.BLL.Generic_Repository.ConcRep;
using Project.ENTITIES.Models;
using Project.ViewModels.VMClasses;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using WebGrease.Css.Ast;

namespace MVC.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category

        CategoryRepository _cRep;
        BookCategoryRepository _bcRep=new BookCategoryRepository();

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
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(AdminCategoryVM categoryVM)
        {
            Category category = new Category()
            {
                CategoryName = categoryVM.CategoryName,
                Description = categoryVM.Description,

            };
            _cRep.Add(category);
            return RedirectToAction("ListCategories");
        }
        public ActionResult UpdateCategory(int id)
        {
            Category cat = _cRep.Find(id);
            AdminCategoryVM categoryVM = new AdminCategoryVM()
            {
                ID = cat.ID,
                CategoryName = cat.CategoryName,
                Description = cat.Description
            };        

            return View(categoryVM);
        }

        [HttpPost]
        public ActionResult UpdateCategory(AdminCategoryVM categoryVM)
        {
            Category secilen = _cRep.Find(categoryVM.ID);
            secilen.ID = categoryVM.ID;
            secilen.CategoryName = categoryVM.CategoryName;
            secilen.Description = categoryVM.Description;
            _cRep.Update(secilen);
            
            return RedirectToAction("ListCategories");
        }
        public ActionResult DeleteCategory(int id)
        {
         //Category cat=_cRep.Find(id);
         //_cRep.Remove(cat);  // uzun yöntem

            _cRep.Remove(_cRep.Find(id));
            return RedirectToAction("ListCategories");
        }
        public ActionResult Deneme()
        {

            return View(_bcRep.GetActives());
        }
    }
}
