using OELS.Core.DTOs.Auth;
using OELS.Core.Repositories;
using OELS.Core.Services;
using OELS.Core.UnitOfWorks;
using OELS.Service.Exceptions;

namespace OELS.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _uow;

        public AuthService(IUserRepository userRepository, ITokenService tokenService, IUnitOfWork uow)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _uow = uow;
        }

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

        public Task RefreshToken(string OldToken)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterDto> RegisterAsync(RegisterDto request)
        {
            throw new NotImplementedException();
        }
    }
}
