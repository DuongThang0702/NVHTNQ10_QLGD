using Business.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Auth
{
    public interface IAuthService
    {
        Task<IdentityResult> SignIn(SignInDto data);
        Task<IdentityResult> SignUp(SignUpDto data);
    }
}
