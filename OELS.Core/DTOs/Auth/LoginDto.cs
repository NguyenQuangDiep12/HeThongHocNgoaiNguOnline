using System.ComponentModel.DataAnnotations;

namespace OELS.Core.DTOs.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email khong duoc de trong!")]
        [EmailAddress(ErrorMessage = "Email khong hop le.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password khong duoc de trong!")]
        [MinLength(8, ErrorMessage = "Password phai co toi thieu 8 ky tu")]
        public string Password { get; set; } = null!;
    }
}
