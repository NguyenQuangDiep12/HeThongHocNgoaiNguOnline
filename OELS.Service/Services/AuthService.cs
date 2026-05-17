using OELS.Core.DTOs.Auth;
using OELS.Core.Repositories;
using OELS.Core.Services;
using OELS.Core.UnitOfWorks;
using OELS.Service.Exceptions;
using OELS.Core.DTOs;
using OELS.Core.Models;

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

        public async Task<AuthResponseDto> LoginAsync(LoginDto request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
            {
                throw new UnauthorizedException("Email hoac mat khau khong dung.");
            }
            // neu tim thay user
            // xac thuc password_hash
            bool isMatch = BCrypt.Net.BCrypt.Verify(request.Password, user.Password_Hash);
            if (!isMatch) throw new UnauthorizedAccessException("Email hoac Password khong dung");

            // Xac thuc thanh cong tao token gui di
            var token = _tokenService.GenerateToken(user);

            return new AuthResponseDto
            {
                AccessToken = token,
                User = new UserResponseDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    AvatarUrl = user.Avatar_Url,
                    Role = user.Role.ToString(),
                }
            };
        }

        public Task RefreshToken(string OldToken)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            // truong hop neu nhu da dang ky roi
            if (user != null) throw new DuplicateEmailException($"Email {request.Email} da duoc dang ky trong he thong");

            // tai khoan email chua dang ky

            var newUser = new User
            {
                Email = request.Email,
                FullName = request.FullName,
                Role = request.Role,
                Password_Hash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            };

            await _userRepository.AddAsync(newUser);
            await _uow.CommitAsync();

            var token = _tokenService.GenerateToken(newUser);

            return new AuthResponseDto
            {
                AccessToken = token,
                User = new UserResponseDto
                {
                    Email = newUser.Email,
                    FullName = newUser.FullName,
                    AvatarUrl=newUser.Avatar_Url,
                    Role = newUser.Role.ToString(),
                    CreatedAt = DateTime.UtcNow,
                }
            };
        }
    }
}
