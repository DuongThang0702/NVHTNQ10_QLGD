﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Auth
{
    public interface IAuthRepo
    {
        Task<IdentityResult> SignUp(string Email, string FullName, string Password);
        Task<string> SignIn(string Email, string Password);
        Task<IdentityResult> RestPassword(string Email, string currentPassword, string newPassword);
    }
}
