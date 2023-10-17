using Business.Dtos;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Teacher
{
    public interface ITeacherService
    {
        Task<List<ApplicationUser>?> GetAllTeacher();
        Task<IdentityResult> CreateTeacher(CreateTeacherDto data);
        Task<IdentityResult> UpdateInfo(UpdateInfoTeacherDto data, string userId);
    }
}
