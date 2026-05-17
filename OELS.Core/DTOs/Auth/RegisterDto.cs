using OELS.Core.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace OELS.Core.DTOs.Auth
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Ho ten khong duoc de trong!")]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;
        [Required(ErrorMessage = "Email khong duoc de trong!")]
        [EmailAddress(ErrorMessage = "Email khong hop le.")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Mat khau khong duoc bo trong!")]
        [MinLength(8, ErrorMessage = "Mat khau toi thieu 8 ky tu.")]
        public string Password { get; set; } = null!;
        [Required]
        [Compare("Password", ErrorMessage = "Mat khau xac nhan khong khop!")]
        public string ConfirmPassword { get; set; } = null!;
        public Role Role { get; set; } = Role.STUDENT;

    }
}
