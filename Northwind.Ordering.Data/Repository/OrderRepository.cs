using Microsoft.EntityFrameworkCore;
using Northwind.Ordering.Data.Database;
using Northwind.Ordering.Data.Database.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Ordering.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly NorthwindDbContext _context;

        public OrderRepository(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task AddOrderItem(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetOrder(int orderId)
        {
            return await _context.Orders.Where(o => o.OrderID == orderId)
                .Include(o => o.OrderDetails)
                .ThenInclude(c => c.Product)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProducts(int categoryId)
        {
            return await _context.Products.Where(
                p => p.CategoryID == categoryId).ToListAsync();
        }

        public async Task<OrderDetail> GetOrderItem(int orderId, int productId)
        {
            return await _context.OrderDetails.Where(
                p => p.OrderID == orderId && p.ProductID == productId)
                .FirstOrDefaultAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
