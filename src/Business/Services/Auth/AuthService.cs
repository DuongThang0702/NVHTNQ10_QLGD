using Business.Dtos;
using Data.Repositories.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepo _userRepo;
        public AuthService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public Task<IdentityResult> SignIn(SignInDto data)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> SignUp(SignUpDto data)
        {
            if (string.IsNullOrEmpty(data.FullName) 
                || string.IsNullOrEmpty(data.Email) 
                || string.IsNullOrEmpty(data.Password)) 
                return IdentityResult.Failed(new IdentityError { Code = "InvalidData", Description = "Invalid data" }); 
            var response = await _userRepo.CreateUser(data.Email, data.FullName, data.Password);
            return response;
        }
    }
}
