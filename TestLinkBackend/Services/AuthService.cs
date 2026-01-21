using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public class AuthService : IAuthService
    {
        private static readonly List<User> _users = new()
        {
            new User { Id = 1, Login = "admin", Password = "password", RoleId = 1, Email = "admin@testlink.com", First = "Admin", Last = "User", Active = true },
            new User { Id = 2, Login = "testuser", Password = "password", RoleId = 2, Email = "user@testlink.com", First = "Test", Last = "User", Active = true }
        };

        public async Task<AuthResponse> LoginAsync(LoginModel loginModel)
        {
            var user = _users.FirstOrDefault(u => u.Login == loginModel.Username && u.Password == loginModel.Password);
            if (user == null)
                throw new UnauthorizedAccessException("Invalid credentials");

            return new AuthResponse
            {
                Token = "mock-jwt-token",
                Expiration = DateTime.UtcNow.AddHours(1),
                User = user
            };
        }

        public async Task<AuthResponse> RegisterAsync(RegisterModel registerModel)
        {
            if (_users.Any(u => u.Login == registerModel.Username))
                throw new InvalidOperationException("User already exists");

            var user = new User
            {
                Id = _users.Max(u => u.Id) + 1,
                Login = registerModel.Username,
                Password = registerModel.Password,
                Email = registerModel.Email,
                First = registerModel.FirstName,
                Last = registerModel.LastName,
                Active = true,
                RoleId = 2
            };

            _users.Add(user);

            return new AuthResponse
            {
                Token = "mock-jwt-token",
                Expiration = DateTime.UtcNow.AddHours(1),
                User = user
            };
        }

        public async Task<User> GetCurrentUserAsync(string username)
        {
            return _users.FirstOrDefault(u => u.Login == username);
        }
    }
}
