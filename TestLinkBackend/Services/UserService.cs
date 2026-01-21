using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public class UserService : IUserService
    {
        private static readonly List<User> _users = new()
        {
            new User { Id = 1, Login = "admin", Password = "password", RoleId = 1, Email = "admin@testlink.com", First = "Admin", Last = "User", Active = true },
            new User { Id = 2, Login = "testuser", Password = "password", RoleId = 2, Email = "user@testlink.com", First = "Test", Last = "User", Active = true }
        };

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return _users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public async Task<User> CreateAsync(User user)
        {
            user.Id = _users.Max(u => u.Id) + 1;
            _users.Add(user);
            return user;
        }

        public async Task<User> UpdateAsync(int id, User user)
        {
            var existing = _users.FirstOrDefault(u => u.Id == id);
            if (existing == null) return null;

            existing.Login = user.Login;
            existing.Email = user.Email;
            existing.First = user.First;
            existing.Last = user.Last;
            existing.Active = user.Active;

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return false;

            _users.Remove(user);
            return true;
        }

        public async Task<User> GetByLoginAsync(string login)
        {
            return _users.FirstOrDefault(u => u.Login == login);
        }

        public async Task AssignRoleAsync(int userId, int testProjectId, int roleId)
        {
            // Mock role assignment
            await Task.CompletedTask;
        }
    }
}
