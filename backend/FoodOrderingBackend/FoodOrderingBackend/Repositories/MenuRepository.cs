using Microsoft.EntityFrameworkCore;
using FoodOrderingBackend.Data;
using FoodOrderingBackend.Models;

namespace FoodOrderingBackend.Repositories
{
    public class MenuRepository
    {
        private readonly AppDbContext _context;

        public MenuRepository(AppDbContext context)
        {
            _context = context;
        }

        // Add menu item
        public async Task<MenuItem> AddMenuItemAsync(MenuItem item)
        {
            _context.MenuItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        // Get all menu items
        public async Task<List<MenuItem>> GetAllMenuItemsAsync()
        {
            return await _context.MenuItems.ToListAsync();
        }

        // Get menu item by Id
        public async Task<MenuItem?> GetMenuItemByIdAsync(int id)
        {
            return await _context.MenuItems.FindAsync(id);
        }

        // Update menu item
        public async Task<MenuItem> UpdateMenuItemAsync(MenuItem item)
        {
            _context.MenuItems.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        // Delete menu item
        public async Task<bool> DeleteMenuItemAsync(int id)
        {
            var item = await _context.MenuItems.FindAsync(id);

            if (item == null)
                return false;

            _context.MenuItems.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}