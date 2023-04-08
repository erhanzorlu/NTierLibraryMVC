using MVC.Areas.Admin.Data.AdminPageVMs;
using Project.BLL.Generic_Repository.ConcRep;
using Project.ENTITIES.Models;
using Project.ViewModels.VMClasses;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    public class BookController : Controller
    {
        // GET: Admin/Book
        BookRepository _bokRep;
        CategoryRepository _catRep;
        AuthorRepository _authorRep;
        BookCategoryRepository _bookCategoryRep;

        public BookController()
        {
            _bokRep = new BookRepository();
            _catRep = new CategoryRepository();
            _authorRep = new AuthorRepository();
            _bookCategoryRep = new BookCategoryRepository();
        }
        public ActionResult ListProduct()
        {
            #region Gereksiz
            //List<AdminAuthorVM> authorVMs = _authorRep.Select(x => new AdminAuthorVM
            //{
            //    FirstName = x.FirstName,
            //    LastName = x.LastName,
            //}).ToList();

            //List<AdminCategoryVM> categoryVMs = _catRep.Select(x => new AdminCategoryVM
            //{
            //    CategoryName = x.CategoryName,

            //}).ToList();

            //List<AdminBookCategoryVM> adminBookCategoryVMs = _bookCategoryRep.Select(x => new AdminBookCategoryVM
            //{

            //}).ToList();

            #endregion
            List<AdminBookVM> bookVMs = _bookCategoryRep.Select(x => new AdminBookVM
            {
                ID = x.BookID,
                BookName = x.Book.BookName,
                CreatedDate = x.Book.CreatedTime,
                ModifiedDate = x.Book.UpdatedTime,
                DeletedDate = x.Book.DeletedTime,
                Page = x.Book.Page,
                PhotoPath = x.Book.PhotoPath,
                Price = x.Book.Price,
                Status = x.Book.Status.ToString(),
                AuthorName = x.Book.Author.FirstName,
                AuthorLastName = x.Book.Author.LastName,
                CategoryName = x.Category.CategoryName


            }).ToList();



            AdminBookListPageVM adminBookListPageVM = new AdminBookListPageVM()
            {
                Books = bookVMs,
            };


            return View(adminBookListPageVM);
        }


        public ActionResult AddBook()
        {
            List<AdminAuthorVM> authorVMs = _authorRep.Select(x => new AdminAuthorVM
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
            }).ToList();

            List<AdminCategoryVM> categoryVMs = _catRep.Select(x => new AdminCategoryVM
            {
                ID = x.ID,
                CategoryName = x.CategoryName,

            }).ToList();


            AdminCreateUpdateBookVM acubvm = new AdminCreateUpdateBookVM()
            {
                AdminAuthors = authorVMs,
                AdminCategoryVMs = categoryVMs,
            };

            return View(acubvm);
        }

        [HttpPost]
        public ActionResult AddBook(AdminBookVM AdminBookVMs)
        {
            Book book = new Book()
            {
                BookName = AdminBookVMs.BookName,
                Page = AdminBookVMs.Page,
                PhotoPath = AdminBookVMs.PhotoPath,
                Price = AdminBookVMs.Price,
                AuthorID = AdminBookVMs.AuthorID

            };
            _bokRep.Add(book);
            BookCategory bookCategory = new BookCategory()
            {
                BookID = book.ID,
                CategoryID = AdminBookVMs.CategoryID


            };

            _bookCategoryRep.Add(bookCategory);

            return RedirectToAction("ListProduct");
        }
        public ActionResult UpdateBook(int id)
        {
            AdminBookVM adminBookV=_bokRep.Select(x=> new AdminBookVM { 
            
                ID = x.ID,
                BookName=x.BookName,
                Page = x.Page,  
                PhotoPath = x.PhotoPath,
                Price = x.Price,

            }).FirstOrDefault(x=>x.ID==id);

            List<AdminAuthorVM> authorVMs = _authorRep.Select(x => new AdminAuthorVM
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
            }).ToList();

            List<AdminCategoryVM> categoryVMs = _catRep.Select(x => new AdminCategoryVM
            {
                ID = x.ID,
                CategoryName = x.CategoryName,

            }).ToList();


            AdminCreateUpdateBookVM acubvm = new AdminCreateUpdateBookVM()
            {
                AdminAuthors = authorVMs,
                AdminCategoryVMs = categoryVMs,
                AdminBookVMs= adminBookV
            };


            return View(acubvm);
        }

        [HttpPost]
        public ActionResult UpdateBook(AdminBookVM AdminBookVMs,int? id)
        {
            Book secilen = _bokRep.Find(AdminBookVMs.ID);
            secilen.BookName = AdminBookVMs.BookName;
            secilen.Page = AdminBookVMs.Page;
            secilen.Price = AdminBookVMs.Price;
            secilen.PhotoPath = AdminBookVMs.PhotoPath;
            secilen.AuthorID = AdminBookVMs.AuthorID;
            _bokRep.Update(secilen);

            //var bookCategory = _bookCategoryRep.FirstOrdDefault(x => x.BookID == id);
            //bookCategory.BookID = AdminBookVMs.ID;
            //bookCategory.CategoryID = AdminBookVMs.CategoryID;
            //_bookCategoryRep.Update(bookCategory);  // Çalışmıyor 
            return RedirectToAction("ListProduct");

        }
        public ActionResult DeleteBook(int id)
        {
            _bokRep.Remove(_bokRep.Find(id));
            return RedirectToAction("ListProduct");
        }
    }
}