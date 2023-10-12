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
        Task<IdentityResult> DeleteUser(string userID);
    }
}
