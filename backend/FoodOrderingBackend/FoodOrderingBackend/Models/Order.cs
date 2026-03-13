namespace FoodOrderingBackend.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderType { get; set; } // DineIn/Takeaway/Delivery
        public string Address { get; set; }
        public List<OrderItem> Items { get; set; }
        public string Status { get; set; } = "Placed";
    }
}
