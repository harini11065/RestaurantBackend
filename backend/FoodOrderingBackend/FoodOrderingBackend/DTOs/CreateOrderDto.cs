using System.Collections.Generic;

namespace FoodOrderingBackend.DTOs
{
    public class CreateOrderDto
    {
        public string OrderType { get; set; } = string.Empty;   // DineIn / Takeaway / Delivery

        public string Address { get; set; } = string.Empty;     // Delivery address

        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }
}
