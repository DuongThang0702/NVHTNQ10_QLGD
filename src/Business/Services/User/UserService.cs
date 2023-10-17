using Business.Dtos;
using Data.Entities;
using Data.Model;
using Data.Repositories.User;
using Microsoft.AspNetCore.Identity;

namespace Business.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<IdentityResult> DeleteUser(string userID)
        {
            var response = await _userRepo.Delete(userID);
            return response;
        }

        public async Task<ResponseGetUserDto> GetAllUser()
        {
            var users = await _userRepo.GetAll();
            if (users == null)
                return new ResponseGetUserDto { Status = false };
            long totalUsers = users.Count;
            var result = new ResponseGetUserDto
            {
                TotalUsers = totalUsers,
                Users = users,
                Status = true
            };
            return result;
        }

        public async Task<ApplicationUser> GetOneUser(string userId)
        {
            var user = await _userRepo.GetOneById(userId)!;
            return user;
        }

        public async Task<IdentityResult> UpdateUser(string userId, UpdateInfoUserDto data)
        {
            var infofUser = new UpdateInfoUser
            {
                Address = data.Address,
                DateOfBirth = data.DateOfBirth,
                FirstName = data.FirstName,
                LastName = data.LastName,
                ParentName = data.ParentName,
                PhoneNumber = data.PhoneNumber
            };
            return await _userRepo.Update(userId, infofUser);
        }
    }
}
