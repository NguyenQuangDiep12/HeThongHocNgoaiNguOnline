using OELS.Core.DTOs.Auth;
using OELS.Core.Repositories;
using OELS.Core.Services;
using OELS.Core.UnitOfWorks;
using OELS.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OELS.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _uow;
        public Task<LoginDto> LoginAsync(LoginDto request)
        {
            var user = _userRepository.GetByEmailAsync(request.Email);
            if(user == null)
            {
                throw new UnauthorizedException("Email hoac mat khau khong dung.");
            }

            // neu tim thay user
            // xac thuc password_hash
            
        }

        public Task<RegisterDto> RegisterAsync(RegisterDto request)
        {
            throw new NotImplementedException();
        }
    }
}
