using MVC.CustomTools;
using MVC.Models;
using MVC.Models.PageVMs;
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
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC.Controllers
{
    public class ShoppingController : Controller
    {
        BookRepository _bokRep;
        CategoryRepository _catRep;
        OrderRepository _oRep=new OrderRepository();
        OrderDetailRepository _odRep = new OrderDetailRepository();

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
            Cart c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart;
            Book eklenecekUrun = _bokRep.Find(id);
            CartItem ci = new CartItem()
            {
                ID = eklenecekUrun.ID,
                UnitPrice = eklenecekUrun.Price,
                BookName = eklenecekUrun.BookName,
                ImagePath = eklenecekUrun.PhotoPath

            };

            c.SepeteEkle(ci);
            Session["scart"] = c;
            TempData["mesaj"] = $"{ci.BookName} isimli ürün sepete eklenmiştir";
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
            CartItem ci = new CartItem()
            {
                ID=eklenecekUrun.ID,
                UnitPrice=eklenecekUrun.Price,
                BookName=eklenecekUrun.BookName,
                ImagePath=eklenecekUrun.PhotoPath

            };
            
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
            
            return View();

        }
        //http://localhost:51914/api/Payment/ReceivePayment
        [HttpPost]
        public ActionResult ConfirmOrder(OrderVM ovm)
        {
            bool sonuc;
            Cart sepet = Session["scart"] as Cart;
            ovm.Order.TotalPrice = ovm.PaymentRM.ShoppingPrice = sepet.TotalPrice;

            #region APISection


            using (HttpClient client=new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51914/api/");
                Task<HttpResponseMessage> postTask = client.PostAsJsonAsync("Payment/ReceivePayment",ovm.PaymentRM);

                HttpResponseMessage result;
                try
                {
                    result = postTask.Result;
                }
                catch (Exception ex)
                {

                    TempData["baglantiRed"] = "Banka baglantiyi reddetti";
                    return RedirectToAction("ShoppingList");
                }
                if (result.IsSuccessStatusCode) sonuc = true;
                else sonuc = false;

                if (sonuc)
                {
                    if (Session["member"]!=null)
                    {
                        AppUser kullanici = Session["member"] as AppUser;
                        ovm.Order.AppUserID = kullanici.ID;
                    }
                    _oRep.Add(ovm.Order);
                    foreach (CartItem item in sepet.Sepetim)
                    {
                        OrderDetail od = new OrderDetail();
                        od.OrderID = ovm.Order.ID;
                        od.BookID = item.ID;
                        od.TotalPrice = item.Amount;
                        _odRep.Add(od);

                        Book StoktanDusurulecek = _bokRep.Find(item.ID);
                        StoktanDusurulecek.UnitInStock -= item.Amount;
                        _bokRep.Update(StoktanDusurulecek);

                        // todo: Stoktan fazla alırsa sipariş alınmasın
                       
                    }

                    TempData["odeme"] = "Siparişiniz bize ulaşmıştır... Teşekkür ederiz";

                    Session.Remove("scart");
                    return RedirectToAction("ShoppingList");

                }
                else
                {
                    Task<string> s=result.Content.ReadAsStringAsync();
                    TempData["sorun"] = s;
                    return RedirectToAction("ShoppingList");
                }
            }

            #endregion
         
        }
    }
}