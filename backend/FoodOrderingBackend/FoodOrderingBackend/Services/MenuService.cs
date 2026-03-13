using FoodOrderingBackend.DTOs;
using FoodOrderingBackend.Models;
using FoodOrderingBackend.Repositories;

namespace FoodOrderingBackend.Services
{
    public class MenuService
    {
        private readonly MenuRepository _menuRepository;

        public MenuService(MenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        // Add menu item
        public async Task<MenuItem> AddMenuItemAsync(MenuItemDto dto)
        {
            var item = new MenuItem
            {
                Name = dto.Name,
                Price = dto.Price,
                Category = dto.Category
            };

            return await _menuRepository.AddMenuItemAsync(item);
        }

        // Get menu items
        public async Task<List<MenuItem>> GetMenuItemsAsync()
        {
            return await _menuRepository.GetAllMenuItemsAsync();
        }

        // Delete menu item
        public async Task<bool> DeleteMenuItemAsync(int id)
        {
            return await _menuRepository.DeleteMenuItemAsync(id);
        }
    }
}