using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniOrderAPI.Dtos;
using MiniOrderAPI.Services;

namespace MiniOrderAPI.Controllers
{
   
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly OrderServices _service;
        public OrderController(OrderServices service)
        {
            _service = service;
        }

        [HttpGet("list")]
        public IActionResult GetOrders(int pageNumber, int pageSize)
        {
            var orders = _service.GetOrders(pageNumber, pageSize);
            return Ok(orders);
        }

        [HttpGet("GetOrder/{orderId}")]
        public IActionResult GetOrderById(int orderId)
        {
            var orders = _service.GetOrders(orderId);
            return Ok(orders);
        }

        [HttpPost("addOrder")]
        public IActionResult CreateOrder(OrderDtos dto)
        {
            _service.CreateOrder(dto);
            return Ok();
        }

        [HttpPatch("update")]
        public IActionResult UpdateOrder(OrderDtos dto)
        {
            _service.CreateOrder(dto);
            return Ok();
        }

        [HttpPost("addOrderItem")]
        public IActionResult CreateOrderItem(OrderItemDtos itemDto)
        {
            _service.CreateOrderItem(itemDto);
            return Ok();
        }
    }
}
