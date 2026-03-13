using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController :Controller
    {
        private readonly OrderService _service;
        public OrdersController(OrderService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
        {
            var order = await _service.CreateOrderAsync(dto);
            return Ok(new { orderId = order.Id, status = order.Status });
        }
    }
}
