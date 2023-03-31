using MVC.CustomTools;
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
            c.SepeteEkle(ci);
            Session["scart"] = c;
            TempData["mesaj"] = $"{ci.BookName} isimli ürün sepete eklenmiştir";
            //return new RedirectToRouteResult(new RouteValueDictionary(new { Action="Index",Controller="Home"}));
            return View();

            
        }
    }
}