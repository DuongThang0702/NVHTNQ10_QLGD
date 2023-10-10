using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos
{
    public class ResponseGetUserDto
    {
        public bool Status { get; set; }
        public long TotalUsers { get; set; }
        public List<ApplicationUser>? Users { get; set; }
    }

    public class ResetPasswordDto
    {
        [Required]
        [MinLength(6)]
        public string? NewPassword { get; set; }
    }

    public class ResponseResetPasswordDto
    {
        public bool Status { get; set; }
        public string Mes { get; set; } = string.Empty;
    }
}
