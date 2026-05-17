using OELS.Core.DTOs;

namespace OELS.Core.DTOs.Auth
{
    public class AuthResponseDto
    {
        public string AccessToken { get; set; } = null!;
        public UserResponseDto User { get; set; } = null!;
    }
}
