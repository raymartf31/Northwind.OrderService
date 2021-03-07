using System;
using System.Collections.Generic;

namespace Northwind.Ordering.Data.Database.Dto
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
