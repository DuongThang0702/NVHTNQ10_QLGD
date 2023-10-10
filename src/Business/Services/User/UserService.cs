using Business.Dtos;
using Data.Repositories.User;

namespace Business.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<ResponseGetUserDto> GetAllUser()
        {
            var users = await _userRepo.GetAll();
            if (users == null) return new ResponseGetUserDto { Status = false };
            long totalUsers = users.Count;
            var result = new ResponseGetUserDto { TotalUsers = totalUsers, Users = users, Status = true };
            return result;
        }

        public async Task<ResponseResetPasswordDto> ResetPassword(ResetPasswordDto data, string userID)
        {
            if (string.IsNullOrEmpty(data.NewPassword)) return new ResponseResetPasswordDto { Status = false, Mes = "Missing input" };
            var response = await _userRepo.RestPassword(userID, data.NewPassword);
            if (!response.Succeeded) return new ResponseResetPasswordDto { Mes = "Failed", Status = false };
            else return new ResponseResetPasswordDto { Status = true, Mes = "Success" };
        }
    }
}
