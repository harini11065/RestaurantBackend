using FoodOrderingBackend.Models;

namespace FoodOrderingBackend.Factories
{
    public class OrderFactory
    {
        public static Order CreateOrder(string type, string address, List<OrderItem> items)
        {
            return type switch
            {
                "DineIn" => new Order { OrderType = "DineIn", Address = address, Items = items },
                "Takeaway" => new Order { OrderType = "Takeaway", Address = address, Items = items },
                "Delivery" => new Order { OrderType = "Delivery", Address = address, Items = items },
                _ => throw new ArgumentException("Invalid order type")
            };
        }
    }
}
