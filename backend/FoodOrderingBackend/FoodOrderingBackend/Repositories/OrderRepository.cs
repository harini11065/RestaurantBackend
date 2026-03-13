

using Microsoft.EntityFrameworkCore;
using FoodOrderingBackend.Data;
using FoodOrderingBackend.Models;

public class OrderRepository
{
    private readonly AppDbContext _context;
    public OrderRepository(AppDbContext context) => _context = context;

    public async Task<Order> AddOrderAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<List<Order>> GetOrdersAsync()
        => await _context.Orders.Include(o => o.Items).ToListAsync();
}