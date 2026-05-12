using MiniOrderAPI.Dtos;
using MiniOrderAPI.Entity;

namespace MiniOrderAPI.Interface
{
    public interface IOrderServices
    {
        public Task<List<Order>> GetOrders(int pageNumber, int pageSize);
        public Task<Order> GetOrders(int orderId);
        public void  CreateOrder(OrderDtos dto);
        public void UpdateOrder(OrderDtos dto);
        public void CreateOrderItem(OrderItemDtos dto);
    }
}
