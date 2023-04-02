using MVC.CustomTools;
using MVC.Models;
using Project.BLL.DesignPatterns.SingletonPattern;
using Project.DAL.ContextClasses;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC.Controllers
{
    public class ShoppingController : Controller
    {
        MyContext db;
        public ShoppingController()
        {
            db = DBTool.DB;
        }
        public ActionResult AddToCart(int id)
        {
            Cart c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart;
            Book eklenecekUrun = db.Books.Find(id);
            CartItem ci = new CartItem();
            ci.BookName = eklenecekUrun.BookName;
            ci.ID = eklenecekUrun.ID;
            ci.UnitPrice = eklenecekUrun.Price;
            ci.ImagePath = eklenecekUrun.PhotoPath;
            c.SepeteEkle(ci);
            Session["scart"] = c;
            TempData["mesaj"] = $"{ci.BookName} isimli ürün sepete eklenmiştir";
            return RedirectToAction("Index","Home"); 

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
    }
}