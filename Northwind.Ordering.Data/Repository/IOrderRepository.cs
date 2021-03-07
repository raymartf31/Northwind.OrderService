using Northwind.Ordering.Data.Database.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Ordering.Data.Repository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrder(int orderId);

        Task<List<Product>> GetProducts(int categoryId);

        Task AddOrderItem(OrderDetail orderDetail);

        Task<OrderDetail> GetOrderItem(int orderId, int productId);

        Task SaveChanges();
    }
}
