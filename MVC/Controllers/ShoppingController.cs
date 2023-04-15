using MVC.CustomTools;
using MVC.Models;
using MVC.Models.ShoppingTools;
using PagedList;
using Project.BLL.DesignPatterns.SingletonPattern;
using Project.BLL.Generic_Repository.ConcRep;
using Project.DAL.ContextClasses;
using Project.ENTITIES.Models;
using Project.ViewModels.VMClasses;
using Project.ViewModels.VMClasses.AdminVM;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC.Controllers
{
    public class ShoppingController : Controller
    {
        BookRepository _bokRep;
        CategoryRepository _catRep;

        public ShoppingController()
        {
           _bokRep = new BookRepository();
            _catRep = new CategoryRepository();


        }
        public ActionResult ShoppingList(int? page,int? categoryID)
        {
            
            PaginationVM paginationVM = new PaginationVM()
            {
             PagedBooks=categoryID==null? _bokRep.GetActives().ToPagedList(page??1,9):_bokRep.Where(x=>x.CategoryID==categoryID).ToPagedList(page??1,9),
             Categories=_catRep.GetActives()
           

            };
            if (categoryID != null) TempData["catID"] = categoryID;

            return View(paginationVM);
        }
        public ActionResult AddToCart(int id)
        {
            SepeteYolla(id);
            return RedirectToAction("Index", "Home");

        }
        public ActionResult CartPage()
        {
            if (Session["scart"]!=null)
            {
                Cart c = Session["scart"] as Cart;
                CartPageVM cartPageVM = new CartPageVM
                {
                    Cart =c,
                };
                return View(cartPageVM);
            }

            ViewBag.SepetBos = "Sepetinizde ürün bulunmamaktadır";
            return View();
        }
        public ActionResult DeleteFromCart(int id)
        {
            if (Session["scart"]!=null)
            {
                Cart c = Session["scart"] as Cart;
                c.SepettenSil(id);
                if (c.Sepetim.Count == 0) Session.Remove("scart");
                return RedirectToAction("CartPage");
                
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult IncreaseAmount(int id)
        {
            SepeteYolla(id);
            return RedirectToAction("CartPage");
        }

        private void SepeteYolla(int id)
        {
            Cart c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart;
            Book eklenecekUrun = _bokRep.Find(id);
            CartItem ci = new CartItem();
            ci.BookName = eklenecekUrun.BookName;
            ci.ID = eklenecekUrun.ID;
            ci.UnitPrice = eklenecekUrun.Price;
            ci.ImagePath = eklenecekUrun.PhotoPath;
            c.SepeteEkle(ci);
            Session["scart"] = c;
            TempData["mesaj"] = $"{ci.BookName} isimli ürün sepete eklenmiştir";
        }
        public ActionResult DestroyFromCart(int id)
        {
            Cart c = Session["scart"] as Cart;
            c.SepettenKaldir(id);
            return RedirectToAction("CartPage");
        }
        public ActionResult ConfirmOrder()
        {
            AppUser currentUser;
            if (Session["member"] != null)
            {
                currentUser = Session["member"] as AppUser;
            }
            else TempData["anonim"] = "Kullanıcı üye değil";
            return View();
        }
    }
}