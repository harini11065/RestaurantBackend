using Microsoft.AspNetCore.Mvc;

namespace FoodOrderingBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController :Controller
    {
        private readonly UserService _service;

        public UsersController(UserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            var user = await _service.CreateUserAsync(dto);
            return Ok(new { userId = user.Id, name = user.Name });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _service.GetUserByIdAsync(id);
            return Ok(user);
        }
    }
}
