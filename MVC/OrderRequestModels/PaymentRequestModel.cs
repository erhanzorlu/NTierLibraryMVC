using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.OrderRequestModels
{
    public class PaymentRequestModel
    {
        public string CardUserName { get; set; }
        public string SecurityNumber { get; set; }
        public string CardNumber { get; set; }
        public int CardExpiryMonth { get; set; }
        public int CardExpiryYear { get; set; }
        public decimal ShoppingPrice { get; set; }
    }
}