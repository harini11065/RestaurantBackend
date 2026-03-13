using FoodOrderingBackend.DTOs;
using FoodOrderingBackend.Models;
using FoodOrderingBackend.Repositories;
using FoodOrderingBackend.Authentication;

namespace FoodOrderingBackend.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly JwtUtils _jwtUtils;

        public UserService(UserRepository userRepository, JwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
        }

        // Register user
        public async Task<User> RegisterUserAsync(UserDto dto)
        {
            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = dto.Password,
                Role = dto.Role
            };

            return await _userRepository.AddUserAsync(user);
        }

        // Login user
        public async Task<string?> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user == null)
                return null;

            if (user.PasswordHash != password)
                return null;

            var token = _jwtUtils.GenerateToken(user.Id, user.Role);

            return token;
        }

        // Get all users
        public async Task<List<User>> GetUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }
    }
}