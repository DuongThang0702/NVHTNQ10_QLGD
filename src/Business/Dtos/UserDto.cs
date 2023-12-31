﻿using Data.Entities;
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

    public class ResponseResetPasswordDto
    {
        public bool Status { get; set; }
        public string Mes { get; set; } = string.Empty;
    }

    public class UpdateInfoUserDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ParentName { get; set; } = string.Empty;
    }
}
