using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.User
{
    public class UserRepo : IUserRepo
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserRepo(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

        }

        public async Task<IdentityResult> CreateUser(string Email, string FullName, string Password)
        {
            var existingUser = await _userManager.FindByEmailAsync(Email);
            if (existingUser != null)
            {
                var error = new IdentityError { Code = "400", Description = "User already exists" };
                return IdentityResult.Failed(error);
            }
            var user = new ApplicationUser { Email = Email, FullName = FullName, UserName = Email };
            var result = await _userManager.CreateAsync(user, Password);
            if (!result.Succeeded)
            {
                var error = new IdentityError { Code = "400", Description = "Something went wrong" };
                return IdentityResult.Failed(error);
            }
            await _userManager.AddToRoleAsync(user, "Student");

            return result;
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }

        public async Task<IdentityResult> RestPassword(string userID, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userID);
            if (user == null)
            {
                IdentityError errors = new() { Code = "400", Description = "User not found" };
                return IdentityResult.Failed(errors);
            };
            var addNewPassword = await _userManager.AddPasswordAsync(user, newPassword);
            if (!addNewPassword.Succeeded) return IdentityResult.Failed();
            else return addNewPassword;
        }
    }
}
