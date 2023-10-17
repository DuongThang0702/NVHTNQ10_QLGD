using Business.Dtos;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.User
{
    public interface IUserService
    {
        Task<ResponseGetUserDto> GetAllUser();
        Task<ApplicationUser> GetOneUser(string userId);
        Task<IdentityResult> DeleteUser(string userID);
        Task<IdentityResult> UpdateUser(string userId, UpdateInfoUserDto data);
    }
}
