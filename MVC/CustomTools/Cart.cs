using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.CustomTools
{
    public class Cart
    {
        Dictionary<int, CartItem> _sepetUrunlerim;
        public Cart()
        {
            _sepetUrunlerim = new Dictionary<int, CartItem>();
        }
        public  List<CartItem> Sepetim
        {
            get
            {
                return _sepetUrunlerim.Values.ToList();
            }
        }
        public void SepeteEkle(CartItem item)
        {
            //Öncelikle sepete daha önce aynı ürün atılmış mı onu sorgularız
            if (_sepetUrunlerim.ContainsKey(item.ID))
            {
                //bir dictonary'e index paranteiz verirseniz o keyi yakalak istediğimizi bildirir
                _sepetUrunlerim[item.ID].Amount++;
                return;
            }
            _sepetUrunlerim.Add(item.ID,item); // 

        }
        public void SepettenSil(int id)
        {
            if (_sepetUrunlerim[id].Amount>1)
            {
                _sepetUrunlerim[id].Amount--;
                return;
            }

            _sepetUrunlerim.Remove(id);
        }

        public decimal? TotalPrice
        {
            get
            {
                return _sepetUrunlerim.Sum(x=>x.Value.SubTotal); 
            }
        }
    }
}