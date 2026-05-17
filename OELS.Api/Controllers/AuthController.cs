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
        [HttpGet("login")]
        public ActionResult<AuthResponseDto> Login(LoginDto request)
        {
            try
            {
                _authService.LoginAsync(request);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);   
            }

            throw new Exception();
            
        }
        [HttpPost("register")]
        public ActionResult<AuthResponseDto> Register()
        {
            throw new NotImplementedException();
        }
    }
}
