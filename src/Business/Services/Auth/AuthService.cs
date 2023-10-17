using Business.Dtos;
using Data.Entities;
using Data.Repositories.Auth;
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
        private readonly IAuthRepo _authRepo;

        public AuthService(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }

        public async Task<SignInResponseDto> SignIn(SignInDto data)
        {
            if (string.IsNullOrEmpty(data.Email) || string.IsNullOrEmpty(data.Password))
                return new SignInResponseDto
                {
                    Mes = "Missing input",
                    Status = false,
                    Access_token = null
                };
            var response = await _authRepo.SignIn(data.Email, data.Password);
            if (string.IsNullOrEmpty(response))
                return new SignInResponseDto
                {
                    Mes = "Wrong Email or Password",
                    Status = false,
                    Access_token = null
                };
            return new SignInResponseDto
            {
                Access_token = response,
                Mes = "Logged in successfully",
                Status = true,
            };
        }

        public async Task<IdentityResult> SignUp(SignUpDto data)
        {
            if (
                string.IsNullOrEmpty(data.Email)
                || string.IsNullOrEmpty(data.Password)
            )
                return IdentityResult.Failed(
                    new IdentityError { Code = "InvalidData", Description = "Invalid data" }
                );
            var response = await _authRepo.SignUp(data.Email, data.Password);
            return response;
        }

        public async Task<IdentityResult> ResetPassword(ResetPasswordDto data)
        {
            if (
                string.IsNullOrEmpty(data.NewPassword)
                || string.IsNullOrEmpty(data.CurrentPassword)
                || string.IsNullOrEmpty(data.Email)
            )
            {
                IdentityError error = new() { Code = "400", Description = "Missing input" };
                return IdentityResult.Failed(error);
            }
            ;
            var response = await _authRepo.RestPassword(
                data.Email,
                data.CurrentPassword,
                data.NewPassword
            );
            return response;
        }

        public async Task<IdentityResult> BlockUser(BlockUserDto data)
        {
            if (string.IsNullOrEmpty(data.UserId))
            {
                IdentityError error = new() { Code = "400", Description = "Missing input" };
                return IdentityResult.Failed(error);
            }
            var result = await _authRepo.BlockUser(data.UserId);
            return result;
        }

        public async Task<IdentityResult> UpdateRoleUser(UpdateRoleUser data)
        {
            if (string.IsNullOrEmpty(data.UserId) || string.IsNullOrEmpty(data.Role))
            {
                IdentityError error = new() { Code = "400", Description = "Missing input" };
                return IdentityResult.Failed(error);
            }
            return await _authRepo.UpdateRoleUser(data.UserId, data.Role);
        }
    }
}
