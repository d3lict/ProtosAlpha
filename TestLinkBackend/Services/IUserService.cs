using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(int id, User user);
        Task<bool> DeleteAsync(int id);
        Task<User> GetByLoginAsync(string login);
        Task AssignRoleAsync(int userId, int testProjectId, int roleId);
    }
}
