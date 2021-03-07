namespace Northwind.Ordering.Data.Database.Dto
{
    public class OrderDetail
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        protected virtual Order Order { get; set; }
        public Product Product { get; set; }
    }
}
