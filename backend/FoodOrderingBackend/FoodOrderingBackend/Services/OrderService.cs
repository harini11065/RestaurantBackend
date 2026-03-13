using FoodOrderingBackend.DTOs;
using FoodOrderingBackend.Models;
using FoodOrderingBackend.Repositories;
using FoodOrderingBackend.Factories;

namespace FoodOrderingBackend.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // Create Order
        public async Task<Order> CreateOrderAsync(CreateOrderDto dto)
        {
            var items = dto.Items.Select(i => new OrderItem
            {
                Name = i.Name,
                Quantity = i.Quantity,
                Price = i.Price
            }).ToList();

            var order = OrderFactory.CreateOrder(dto.OrderType, dto.Address, items);

            return await _orderRepository.AddOrderAsync(order);
        }

        // Get Orders
        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _orderRepository.GetOrdersAsync();
        }
    }
}