using Microsoft.AspNetCore.Mvc;
using TestLinkBackend.Services;

namespace TestLinkBackend.Controllers
{
    [ApiController]
    [Route("")]
    public class ApiController : ControllerBase
    {
        private readonly IAuthService _authService;

        public ApiController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("whoAmI")]
        public async Task<IActionResult> WhoAmI()
        {
            // For demo, return mock user
            var user = new { Login = "admin", First = "Admin", Last = "User" };
            return Ok(user);
        }
    }
}
