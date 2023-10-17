using Data.Entities;
using Data.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Teacher
{
    public interface ITeacherRepo
    {
        Task<List<ApplicationUser>?> GetAll();
        Task<IdentityResult> UpdateInfo(UpdateTeacherModel model, string id);
        Task<IdentityResult> CreateTeacher(CreateTeacherModel model);
    }
}
