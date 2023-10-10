using Business.Dtos;
using Data.Entities;
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
        Task<ResponseResetPasswordDto> ResetPassword(ResetPasswordDto data, string userID);
    }
}
