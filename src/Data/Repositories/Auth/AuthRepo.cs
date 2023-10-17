using Data.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Data.Repositories.Auth
{
    public class AuthRepo : IAuthRepo

    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        public AuthRepo(
            UserManager<ApplicationUser> userManager,
            IConfiguration config,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager
        )
        {
            _userManager = userManager;
            _config = config;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<string> SignIn(string Email, string Password)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
                return string.Empty;
            var matchingPassword = await _signInManager.PasswordSignInAsync(
                user,
                Password,
                false,
                false
            );
            if (!matchingPassword.Succeeded)
                return string.Empty;

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authenKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["JWT:SecretKey"])
            );
            var token = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddMinutes(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(
                    authenKey,
                    SecurityAlgorithms.HmacSha512Signature
                )
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUp(string Email, string Password)
        {
            var existingUser = await _userManager.FindByEmailAsync(Email);
            if (existingUser != null)
            {
                var error = new IdentityError { Code = "400", Description = "User already exists" };
                return IdentityResult.Failed(error);
            }
            var user = new ApplicationUser
            {
                Email = Email,
                UserName = Email
            };
            var result = await _userManager.CreateAsync(user, Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Student");
                return result;
            }
            else
                return IdentityResult.Failed();
        }

        public async Task<IdentityResult> RestPassword(
            string Email,
            string currentPassword,
            string newPassword
        )
        {
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                IdentityError errors = new() { Code = "400", Description = "User not found" };
                return IdentityResult.Failed(errors);
            }
            ;
            var addNewPassword = await _userManager.ChangePasswordAsync(
                user,
                currentPassword,
                newPassword
            );
            return addNewPassword;
        }

        public async Task<IdentityResult> BlockUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                var error = new IdentityError
                {
                    Code = "400",
                    Description = "User not found"
                };
                return IdentityResult.Failed(error);
            }
            user.IsBlocked = true;
            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> UpdateRoleUser(string userId, string role)
        {
            var matchingRoleName = await _roleManager.RoleExistsAsync(role);
            if (!matchingRoleName)
            {
                var error = new IdentityError
                {
                    Code = "400",
                    Description = "Role not found"
                };
                return IdentityResult.Failed(error);
            }
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                var error = new IdentityError
                {
                    Code = "400",
                    Description = "User not found"
                };
                return IdentityResult.Failed(error);
            }

            var oldRole = await _userManager.GetRolesAsync(user);
            if (oldRole == null)
            {
                await _userManager.AddToRoleAsync(user, role);
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, oldRole.FirstOrDefault());
                await _userManager.AddToRoleAsync(user, role);
            }
            return await _userManager.UpdateAsync(user);
        }
    }
}
