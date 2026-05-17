using OELS.Core.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OELS.Core.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginDto request);
        Task<AuthResponseDto> RegisterAsync(RegisterDto request);
        Task RefreshToken(string OldToken);
    }
}
