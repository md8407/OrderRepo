using Microsoft.EntityFrameworkCore;
using MiniOrderAPI.Data;
using MiniOrderAPI.Dtos;
using MiniOrderAPI.Entity;
using MiniOrderAPI.Interface;

namespace MiniOrderAPI.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly ApplicationDbContext _context;
        public OrderServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Order>> GetOrders(int pageNumber, int pageSize)
        {
            if (pageNumber < 1) pageNumber = 1;

            var orders = _context.Orders.OrderBy(o => o.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
           
            return orders;
        }

        public Task<Order> GetOrders(int orderId)
        {
            var order = _context.Orders.FirstOrDefault(ord => ord.Id == orderId);
            return order;
        }

        public void CreateOrder(OrderDtos dto)
        {
            var order = new Order
            {
                CustomerName = dto.CustomerName,
                Status = dto.Status,
                CreatedAt = DateTime.Now
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

        }

        public void UpdateOrder(OrderDtos dto)
        {
            var order = new Order
            {
                Id = dto.Id,
                CustomerName = dto.CustomerName,
                Status = dto.Status,
                CreatedAt = DateTime.Now
            };
            
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void CreateOrderItem(OrderItemDtos dto)
        {
            var orderItem = new OrderItem
            {
                ProductName = dto.ProductName,
                Price = dto.Price,
                Quantity = dto.Quantity,
                OrderId = dto.OrderId
            };

            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();
        }        
    }
}
