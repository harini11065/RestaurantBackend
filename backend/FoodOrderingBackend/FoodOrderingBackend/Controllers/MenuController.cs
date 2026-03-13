using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController:Controller
    {
        private readonly MenuService _service;

        public MenuController(MenuService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuItems()
        {
            var items = await _service.GetMenuItemsAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> AddMenuItem([FromBody] CreateMenuItemDto dto)
        {
            var item = await _service.AddMenuItemAsync(dto);
            return Ok(item);
        }
    }
}
