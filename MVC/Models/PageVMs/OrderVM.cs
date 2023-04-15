using MVC.OrderRequestModels;
using Project.ENTITIES.Models;
using System.Collections.Generic;

namespace MVC.Models.PageVMs
{
    public class OrderVM
    {
        public Order Order { get; set; }
        public List<Order> Orders { get; set; }
        public PaymentRequestModel PaymentRM { get; set; }

    }
}