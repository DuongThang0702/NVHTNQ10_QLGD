using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos
{
    public class SignUpDto
    {
        [Required, EmailAddress]
        public string? Email { get; set; }

        [
            Required,
            MinLength(6),
            RegularExpression(
                @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@$!%*#?&]).{6,}$",
                ErrorMessage = "Password must have at least 1 lowercase letter, 1 uppercase letter, 1 number and 1 special character."
            )
        ]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string? FullName { get; set; }
    }

    public class SignInDto
    {
        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required, MinLength(6)]
        public string? Password { get; set; }
    }

    public class ResetPasswordDto
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        [MinLength(6)]
        public string? CurrentPassword { get; set; }

        [Required]
        [MinLength(6)]
        public string? NewPassword { get; set; }
    }

    public class SignInResponseDto : BaseResponseDto
    {
        public string? Access_token { get; set; }
    }
}
