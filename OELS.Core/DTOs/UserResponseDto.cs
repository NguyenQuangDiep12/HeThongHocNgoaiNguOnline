using System;
namespace OELS.Core.DTOs
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? AvatarUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
