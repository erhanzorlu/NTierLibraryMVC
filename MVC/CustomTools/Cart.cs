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
        public List<CartItem> Sepetim
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
            _sepetUrunlerim.Add(item.ID,item); // 3:21:35

        }
    }
}