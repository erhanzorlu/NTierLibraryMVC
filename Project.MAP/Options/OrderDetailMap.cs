using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class OrderDetailMap:BaseMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            Ignore(x => x.ID);
            HasKey(x => new {
                x.OrderID,
                x.BookID,
            });
        }
    }
}
