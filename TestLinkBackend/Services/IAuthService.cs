using TestLinkBackend.Models;

namespace TestLinkBackend.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(LoginModel loginModel);
        Task<AuthResponse> RegisterAsync(RegisterModel registerModel);
        Task<User> GetCurrentUserAsync(string username);
    }
}
