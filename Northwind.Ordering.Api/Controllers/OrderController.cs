using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Northwind.Ordering.Data.Database.Dto;
using Northwind.Ordering.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Ordering.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders()
        {
            // Hard-coding orderId value for demo purposes.
            int orderId = 10250;

            List<Order> orders = await _orderRepository.GetOrder(orderId);

            return Content(JsonConvert.SerializeObject(orders));
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            // Hard-coding categoryId value for demo purposes.
            int categoryId = 7;

            List<Product> products = await _orderRepository.GetProducts(categoryId);

            return Content(JsonConvert.SerializeObject(products));
        }

        [HttpPost("addorderitem")]
        public async Task<IActionResult> AddOrderItem(OrderDetail orderDetail)
        {
            List<Order> orders = await _orderRepository.GetOrder(orderDetail.OrderID);

            if (orders?.Any() ?? false)
            {
                foreach (Order order in orders)
                {
                    OrderDetail orderItem =
                        await _orderRepository.GetOrderItem(order.OrderID, orderDetail.ProductID);

                    if (orderItem != null)
                    {
                        orderItem.Quantity += 1;
                        await _orderRepository.SaveChanges();
                    }
                    else
                    {
                        await _orderRepository.AddOrderItem(orderDetail);
                    }
                }
            }

            // Other business rules.
            // Update units in stock.
            // Update units in order.

            return Ok(true);
        }
    }
}
