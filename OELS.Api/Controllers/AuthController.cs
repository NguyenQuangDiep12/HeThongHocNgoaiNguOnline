using Microsoft.AspNetCore.Mvc;
using OELS.Core.DTOs.Auth;
using OELS.Core.Services;

namespace OELS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginDto request)
        {
            var result = await _authService.LoginAsync(request);
            return Ok(result);
        }
        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseDto>> Register([FromBody] RegisterDto request)
        {
            var result = await _authService.RegisterAsync(request);
            return Ok(result);
        }
    }
}
