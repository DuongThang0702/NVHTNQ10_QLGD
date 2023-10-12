using Business.Dtos;
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
    }
}
