using Data.Entities;
using Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.User
{
    public class UserRepo : IUserRepo
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepo(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }

        public async Task<IdentityResult> Delete(string userID)
        {
            var user = await _userManager.FindByIdAsync(userID);
            if (user == null)
            {
                IdentityError errors = new() { Code = "400", Description = "User not found" };
                return IdentityResult.Failed(errors);
            }
            return await _userManager.DeleteAsync(user);
        }

        public async Task<IdentityResult> Update(string userId, UpdateInfoUser data)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                IdentityError errors = new() { Code = "400", Description = "User not found" };
                return IdentityResult.Failed(errors);
            }
            user.Address = data.Address;
            user.LastName = data.LastName;
            user.FirstName = data.FirstName;
            user.ParentName = data.ParentName;
            user.PhoneNumber = data.PhoneNumber;
            return await _userManager.UpdateAsync(user);
        }

        public async Task<ApplicationUser>? GetOneById(string userID)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(user => user.Id == userID);
            if (user == null) return null!;
            else return user;
        }
    }
}
